// Copyright (C) Microsoft Corporation. All rights reserved.

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using PlayFab;
using PlayFab.AuthenticationModels;
using PlayFab.CloudScriptModels;
using PlayFab.Internal;
using PlayFab.Json;


namespace AzureFunctions
{


    public static class ExecuteFunction
    {        
        /// <summary>
        /// A local implementation of the ExecuteFunction feature. Provides the ability to execute an Azure Function with a local URL with respect to the host
        /// of the application this function is running in.
        /// </summary>
        /// <param name="functionRequest">The execution request</param>
        /// <param name="httpRequest">The HTTP request</param>
        /// <param name="log">A logger object</param>
        /// <returns>The function execution result(s)</returns>
        [FunctionName("ExecuteFunction")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "CloudScript/ExecuteFunction")] HttpRequest request, ILogger log)
        {
            // Extract the caller's entity token 
            string callerEntityToken = request.Headers["X-EntityToken"];

            // Extract the request body and deserialize
            StreamReader reader = new StreamReader(request.Body);
            string body = await reader.ReadToEndAsync();
            ExecuteFunctionRequest execRequest = PlayFabSimpleJson.DeserializeObject<ExecuteFunctionRequest>(body);
            
            // Grab the title entity token for authentication
            var titleEntityToken = await GetTitleEntityToken();
            var argumentsUri = GetArgumentsUri();
            
            // Prepare the `Get Arguments` request
            var contextRequest = new GetArgumentsForExecuteFunctionRequest
            {
                AuthenticationContext = new PlayFabAuthenticationContext
                {
                    EntityToken = titleEntityToken
                },
                CallingEntity = callerEntityToken,
                Request = execRequest
            };

            // Execute the arguments request
            PlayFabResult<GetArgumentsForExecuteFunctionResult> getArgsResponse = 
                await PlayFabCloudScriptAPI.GetArgumentsForExecuteFunctionAsync(contextRequest);

            // Validate no errors on arguments request
            if (getArgsResponse.Error != null)
            {
                throw new Exception("Failed to retrieve functions argument");
            }

            // Extract the request for the next stage from the get arguments response
            EntityRequest entityRequest = getArgsResponse?.Result?.Request;

            // Assemble the target function's path in the current App
            string routePrefix = GetHostRoutePrefix();
            string functionPath = routePrefix != null ? routePrefix + "/" + execRequest.FunctionName
                : execRequest.FunctionName;

            // Build URI of Azure Function based on current host
            var uriBuilder = new UriBuilder
            {
                Host = request.Host.Host,
                Port = request.Host.Port ?? 80,
                Path = functionPath
            };

            // Serialize the request to the azure function and add headers
            var functionRequestContent = new StringContent(PlayFabSimpleJson.SerializeObject(entityRequest));
            functionRequestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var sw = new Stopwatch();
            sw.Start();

            // Execute the local azure function
            using (var client = new HttpClient())
            {
                using (HttpResponseMessage functionResponseMessage =
                    await client.PostAsync(uriBuilder.Uri.AbsoluteUri, functionRequestContent))
                {
                    sw.Stop();
                    double executionTime = sw.ElapsedMilliseconds;

                    // Extract the response content
                    using (HttpContent functionResponseContent = functionResponseMessage.Content)
                    {
                        string functionResponseString = await functionResponseContent.ReadAsStringAsync();

                        // Prepare a response to reply back to client with and include function execution results
                        var functionResult = new ExecuteFunctionResult
                        {
                            FunctionName = execRequest.FunctionName,
                            FunctionResult = PlayFabSimpleJson.DeserializeObject(functionResponseString),
                            ExecutionTimeSeconds = executionTime
                        };

                        // Reply back to client with final results
                        var output = new PlayFabJsonSuccess<ExecuteFunctionResult>
                        {
                            code = 200,
                            status = "OK",
                            data = functionResult
                        };
                        var outputStr = PlayFabSimpleJson.SerializeObject(output);
                        return new HttpResponseMessage
                        {
                            Content = new StringContent(outputStr, Encoding.UTF8, "application/json"),
                            StatusCode = HttpStatusCode.OK
                        };
                    }
                }
            }
        }

        public static async Task<string> GetTitleEntityToken()
        {
            PlayFabSettings.staticSettings.DeveloperSecretKey =  Environment.GetEnvironmentVariable("PLAYFAB_TITLE_SECRET_KEY", EnvironmentVariableTarget.Process);
            PlayFabSettings.staticSettings.TitleId = Environment.GetEnvironmentVariable("PLAYFAB_TITLE_ID", EnvironmentVariableTarget.Process);
            //PlayFabSettings.VerticalName = VERTICAL_NAME; //Environment.GetEnvironmentVariable(VERTICAL_NAME, EnvironmentVariableTarget.Process);

            var request = new GetEntityTokenRequest();            
            PlayFabResult<GetEntityTokenResponse> response = await PlayFabAuthenticationAPI.GetEntityTokenAsync(request);
            return response.Result?.EntityToken;
        }

        private static string GetArgumentsUri()
        {
            var sb = new StringBuilder();

            // Append the title name if applicable
            string title = Environment.GetEnvironmentVariable("PLAYFAB_TITLE_ID", EnvironmentVariableTarget.Process);
            if (!string.IsNullOrEmpty(title))
            {
                sb.Append(title).Append(".");
            }
            // Append the vertical name if applicable
            string vertical = Environment.GetEnvironmentVariable("PLAYFAB_VERTICAL_NAME", EnvironmentVariableTarget.Process);
            if (!string.IsNullOrEmpty(vertical))
            {
                sb.Append(vertical).Append(".");
            }
            // Append base PF API address
            sb.Append("playfabapi.com");

            var uriBuilder = new UriBuilder
            {
                Scheme = "https",
                Host = sb.ToString(),
                Path = "/CloudScript/GetArgumentsForExecuteFunction"
            };

            return uriBuilder.Uri.AbsoluteUri;
        }

        public static string ReadAllFileText(string filename)
        {
            StringBuilder sb = new StringBuilder();

            if (!File.Exists(filename))
            {
                return string.Empty;
            }
                
            if (sb == null)
            {
                sb = new StringBuilder();
            }
            sb.Length = 0;

            using (var fs = new FileStream(filename, FileMode.Open))
            {
                using (var br = new BinaryReader(fs))
                {
                    while (br.BaseStream.Position != br.BaseStream.Length)
                    {
                        sb.Append(br.ReadChar());
                    }
                }
            }
            
            return sb.ToString();
        }

        private static string GetHostRoutePrefix()
        {
            string hostFileContent = null;
            string currDir = Directory.GetCurrentDirectory();
            string currDirHostFile = Path.Combine(currDir, "host.json");

            if (File.Exists(currDirHostFile))
            {
                hostFileContent = ReadAllFileText(currDirHostFile);
            }

            HostJsonModel hostModel = PlayFabSimpleJson.DeserializeObject<HostJsonModel>(hostFileContent);

            return hostModel?.extensions?.http?.routePrefix;
        }
    }

    public class HostJsonModel
    {
        public string version { get; set; }
        public HostJsonExtensionsModel extensions { get; set; }

        public class HostJsonExtensionsModel
        {
            public HostJsonHttpModel http { get; set; }
        }

        public class HostJsonHttpModel
        {
            public string routePrefix { get; set;}
        }
    }

    public class PlayFabJsonResult<ResponseType> where ResponseType : PlayFabResultCommon
    {
        public PlayFabJsonSuccess<ResponseType> Result { get; set; }
        public PlayFabJsonError Error { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
