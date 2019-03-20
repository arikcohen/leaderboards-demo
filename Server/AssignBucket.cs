using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PlayFab.CloudScriptModels;
using PlayFab.LeaderboardsModels;
using PlayFab;
using System.Collections.Generic;

namespace playfab.gdc.leaderboardsdemo
{
    public static class AssignBucket
    {
        [FunctionName("AssignBucket")]
        public static async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] EntityRequest req,
            ILogger log)        
        {
            log.LogInformation("Attempting to get TitleEntityToken");
            var titleToken = await AzureFunctions.ExecuteFunction.GetTitleEntityToken();
            var name = req.FunctionParameter.ToString();
            log.LogInformation($"Connected to PlayFab [{titleToken}]");

            
            if ((req.EntityProfile.Statistics != null) && req.EntityProfile.Statistics.ContainsKey("Bucket"))
            {
                
                if (req.EntityProfile.Statistics["Bucket"].Metadata != null)
                {
                    log.LogInformation($"{name} already had bucket statistic but no assignment");
                    return await UpdateBucketMetadata(req, log);
                }
                else
                {
                    log.LogInformation($"{name} already had bucket assigned {req.EntityProfile.Statistics["Bucket"].Metadata}");
                    return req.EntityProfile.Statistics["Bucket"].Metadata;
                }   
                    
            }
            else {
                await PlayFabLeaderboardsAPI.UpdateStatisticsAsync( new UpdateStatisticsRequest() {
                    Entity = new PlayFab.LeaderboardsModels.EntityKey() {
                        Id = req.RequestorEntity.Id,
                        Type = req.RequestorEntity.Type
                    },
                    EntityLeaderboardMetadata = name,
                    Statistics = new System.Collections.Generic.List<StatisticUpdate>() {
                        new StatisticUpdate() {
                            Name = "Bucket",
                            Value = 1
                        }
                    }
                });

                return await UpdateBucketMetadata(req, log);
            }                                
        }

        private static async Task<string> UpdateBucketMetadata(EntityRequest req, ILogger log)
        {
                var rankings = await PlayFabLeaderboardsAPI.GetLeaderboardAroundEntityAsync(new GetLeaderboardAroundEntityRequest() {
                    Entity = new PlayFab.LeaderboardsModels.EntityKey() {
                        Id = req.RequestorEntity.Id,
                        Type = req.RequestorEntity.Type
                    },
                    StatisticName = "Bucket",
                    Offset = 0
                });
                
                int entityRank = rankings.Result.Rankings[0].Rank;
                int bucket = entityRank/5;

                await PlayFabLeaderboardsAPI.UpdateStatisticsAsync( new UpdateStatisticsRequest() {
                    Entity = new PlayFab.LeaderboardsModels.EntityKey() {
                        Id = req.RequestorEntity.Id,
                        Type = req.RequestorEntity.Type
                    },
                    EntityLeaderboardMetadata = (string) req.FunctionParameter,
                    Statistics = new System.Collections.Generic.List<StatisticUpdate>() {
                        new StatisticUpdate() {
                            Name = "Bucket",
                            Value = 1,
                            Metadata = bucket.ToString()
                        }
                    }
                });

                log.LogInformation($"{req.FunctionParameter.ToString()} assigned bucket {bucket}");
                return bucket.ToString();
        }
    }
}
