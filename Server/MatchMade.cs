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
using PlayFab.DataModels;
using PlayFab.EventsModels;
using PlayFab.LeaderboardsModels;
using PlayFab.CloudScriptModels;


namespace playfab.gdc.leaderboardsdemo
{
    public static class MatchMade
    {
        [FunctionName("MatchMade")]
        public static async Task<object> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] EntityRequest<MatchResult> req,
            ILogger log)
        {
            log.LogInformation("Function Started");            
            string titleToken = await AzureFunctions.ExecuteFunction.GetTitleEntityToken();
            //log.LogInformation($"Received login token for Title: {PlayFabSettings.staticSettings.TitleId}");            
            await PlayFabHelpers.WriteEvent(titleToken, PlayFabHelpers.TitleEntityKey, "MatchMade", req.FunctionParameter);

            await PlayFabLeaderboardsAPI.UpdateStatisticsAsync(new UpdateStatisticsRequest() {
                Entity = new PlayFab.LeaderboardsModels.EntityKey() {
                    Id = req.RequestorEntity.Id,
                    Type = req.RequestorEntity.Type                                            
                },                
                Statistics = new System.Collections.Generic.List<StatisticUpdate>() {
                    new StatisticUpdate() {
                        Name="TimeToFindPair",
                        ChildName = req.EntityProfile.Statistics["Bucket"].Metadata,
                        Value= (int) Math.Round(req.FunctionParameter.matchTime*1000),
                        Metadata = JsonConvert.ToString(req.FunctionParameter.cardIndex)
                    }
                }
            }); 
            



            return new {};
        }
    }
}
