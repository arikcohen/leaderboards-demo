using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.EventsModels;
using PlayFab.ProfilesModels;


namespace playfab.gdc.leaderboardsdemo
{
    public class PlayFabHelpers
    {
        static public async Task InitializeSettingsAndConnect()
        {
            PlayFabSettings.staticSettings.TitleId = System.Environment.GetEnvironmentVariable("PLAYFAB_TITLE_ID");
            PlayFabSettings.staticSettings.DeveloperSecretKey = System.Environment.GetEnvironmentVariable("PLAYFAB_TITLE_SECRET_KEY");
            var result = await PlayFabAuthenticationAPI.GetEntityTokenAsync(new PlayFab.AuthenticationModels.GetEntityTokenRequest());
            entityToken = result.Result.EntityToken;            
        }

        static public string entityToken;

        static public PlayFab.EventsModels.EntityKey TitleEntityKey
        {
            get
            {
                return new PlayFab.EventsModels.EntityKey()
                {
                    Id = PlayFab.PlayFabSettings.staticSettings.TitleId,
                    Type = "title"
                };
            }
        }

        static public async Task<WriteEventsResponse> WriteEvent(string titleToken,PlayFab.EventsModels.EntityKey Entity, string eventName, object eventData)
        {
            var request = new WriteEventsRequest();            
            //request.AuthenticationContext = new PlayFabAuthenticationContext() { EntityToken = titleToken};

            request.Events = new List<EventContents>();
            request.Events.Add(new EventContents
            {
                Entity = Entity,
                EventNamespace = System.Environment.GetEnvironmentVariable("PLAYFAB_EVENT_NAMESPACE"),
                Name = eventName,
                Payload = eventData
            });

            var result = await PlayFabEventsAPI.WriteEventsAsync(request);

            return result.Result;
        }
    }
}





