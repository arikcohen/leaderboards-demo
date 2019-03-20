using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.LeaderboardsModels;


namespace Company.Function
{
    public static class RecreateStatistics
    {
        [FunctionName("RecreateStatistics")]
        public static async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {   
            string response = "";         
            string titleToken = await AzureFunctions.ExecuteFunction.GetTitleEntityToken();               
              
            var deleteBucketDef = await PlayFabLeaderboardsAPI.DeleteStatisticDefinitionAsync(new DeleteStatisticDefinitionRequest() {
                Name = "Bucket"
            });
            
            response += JsonConvert.SerializeObject(deleteBucketDef, Formatting.Indented);


            var bucketDef = await PlayFabLeaderboardsAPI.CreateStatisticDefinitionAsync(new CreateStatisticDefinitionRequest() {
                Name = "Bucket",
                AggregationMethod = StatisticAggregationMethod.Max,

                LeaderboardDefinition = new LeaderboardDefinition() {
                    SortDirection = LeaderboardSortDirection.Descending,
                    ProvisionLeaderboard = true            
                }
            });

            response += JsonConvert.SerializeObject(bucketDef.Result, Formatting.Indented);

            var deleteTimeToFindDef = await PlayFabLeaderboardsAPI.DeleteStatisticDefinitionAsync(new DeleteStatisticDefinitionRequest() {
                Name = "TimeToFindPair"
            });

            response += JsonConvert.SerializeObject(deleteTimeToFindDef.Result, Formatting.Indented);


            var timeToFindDef = await PlayFabLeaderboardsAPI.CreateStatisticDefinitionAsync(new CreateStatisticDefinitionRequest() {
                Name = "TimeToFindPair",
                AggregationMethod = StatisticAggregationMethod.Last,

                LeaderboardDefinition = new LeaderboardDefinition() {
                    SortDirection = LeaderboardSortDirection.Ascending,
                    ProvisionLeaderboard = true,
                    DynamicChildLeaderboardMaxSize = 5            
                }
            });

        response += JsonConvert.SerializeObject(timeToFindDef.Result, Formatting.Indented);


        

        return response;
        }
    }
}
