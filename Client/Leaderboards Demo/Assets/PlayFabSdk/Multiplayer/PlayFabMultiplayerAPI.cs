#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.MultiplayerModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// API methods for managing multiplayer servers. API methods for managing parties.
    /// </summary>
    public static partial class PlayFabMultiplayerAPI
    {
        static PlayFabMultiplayerAPI() {}


        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public static void ForgetAllCredentials()
        {
            PlayFabHttp.ForgetAllCredentials();
        }

        /// <summary>
        /// Cancel all active tickets the player is a member of in a given queue.
        /// </summary>
        public static void CancelAllMatchmakingTicketsForPlayer(CancelAllMatchmakingTicketsForPlayerRequest request, Action<CancelAllMatchmakingTicketsForPlayerResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/CancelAllMatchmakingTicketsForPlayer", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Cancel a matchmaking ticket.
        /// </summary>
        public static void CancelMatchmakingTicket(CancelMatchmakingTicketRequest request, Action<CancelMatchmakingTicketResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/CancelMatchmakingTicket", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Creates a multiplayer server build with a custom container.
        /// </summary>
        public static void CreateBuildWithCustomContainer(CreateBuildWithCustomContainerRequest request, Action<CreateBuildWithCustomContainerResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/CreateBuildWithCustomContainer", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Creates a multiplayer server build with a managed container.
        /// </summary>
        public static void CreateBuildWithManagedContainer(CreateBuildWithManagedContainerRequest request, Action<CreateBuildWithManagedContainerResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/CreateBuildWithManagedContainer", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Create a matchmaking ticket as a client.
        /// </summary>
        public static void CreateMatchmakingTicket(CreateMatchmakingTicketRequest request, Action<CreateMatchmakingTicketResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/CreateMatchmakingTicket", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Creates a remote user to log on to a VM for a multiplayer server build.
        /// </summary>
        public static void CreateRemoteUser(CreateRemoteUserRequest request, Action<CreateRemoteUserResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/CreateRemoteUser", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Create a matchmaking ticket as a server. The matchmaking service automatically starts matching the ticket against other
        /// matchmaking tickets.
        /// </summary>
        public static void CreateServerMatchmakingTicket(CreateServerMatchmakingTicketRequest request, Action<CreateMatchmakingTicketResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/CreateServerMatchmakingTicket", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Deletes a multiplayer server game asset for a title.
        /// </summary>
        public static void DeleteAsset(DeleteAssetRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/DeleteAsset", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Deletes a multiplayer server build.
        /// </summary>
        public static void DeleteBuild(DeleteBuildRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/DeleteBuild", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Deletes a multiplayer server game certificate.
        /// </summary>
        public static void DeleteCertificate(DeleteCertificateRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/DeleteCertificate", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Deletes a remote user to log on to a VM for a multiplayer server build.
        /// </summary>
        public static void DeleteRemoteUser(DeleteRemoteUserRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/DeleteRemoteUser", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Enables the multiplayer server feature for a title.
        /// </summary>
        public static void EnableMultiplayerServersForTitle(EnableMultiplayerServersForTitleRequest request, Action<EnableMultiplayerServersForTitleResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/EnableMultiplayerServersForTitle", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Enables the parties feature for a title.
        /// </summary>
        public static void EnablePartiesForTitle(EnablePartiesForTitleRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Party/EnablePartiesForTitle", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets the URL to upload assets to.
        /// </summary>
        public static void GetAssetUploadUrl(GetAssetUploadUrlRequest request, Action<GetAssetUploadUrlResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/GetAssetUploadUrl", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets a multiplayer server build.
        /// </summary>
        public static void GetBuild(GetBuildRequest request, Action<GetBuildResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/GetBuild", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets a token for the cognitive services based on the specified service type.
        /// </summary>
        public static void GetCognitiveServicesToken(GetCognitiveServicesTokenRequest request, Action<GetCognitiveServicesTokenResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/GetCognitiveServicesToken", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets the credentials to the container registry.
        /// </summary>
        public static void GetContainerRegistryCredentials(GetContainerRegistryCredentialsRequest request, Action<GetContainerRegistryCredentialsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/GetContainerRegistryCredentials", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Get a match.
        /// </summary>
        public static void GetMatch(GetMatchRequest request, Action<GetMatchResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/GetMatch", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Get a matchmaking queue configuration.
        /// </summary>
        public static void GetMatchmakingQueue(GetMatchmakingQueueRequest request, Action<GetMatchmakingQueueResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/GetMatchmakingQueue", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Get a matchmaking ticket by ticket Id.
        /// </summary>
        public static void GetMatchmakingTicket(GetMatchmakingTicketRequest request, Action<GetMatchmakingTicketResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/GetMatchmakingTicket", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets multiplayer server session details for a build.
        /// </summary>
        public static void GetMultiplayerServerDetails(GetMultiplayerServerDetailsRequest request, Action<GetMultiplayerServerDetailsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/GetMultiplayerServerDetails", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets multiplayer server logs after a server has terminated.
        /// </summary>
        public static void GetMultiplayerServerLogs(GetMultiplayerServerLogsRequest request, Action<GetMultiplayerServerLogsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/GetMultiplayerServerLogs", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Get the statistics for a queue.
        /// </summary>
        public static void GetQueueStatistics(GetQueueStatisticsRequest request, Action<GetQueueStatisticsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/GetQueueStatistics", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets a remote login endpoint to a VM that is hosting a multiplayer server build.
        /// </summary>
        public static void GetRemoteLoginEndpoint(GetRemoteLoginEndpointRequest request, Action<GetRemoteLoginEndpointResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/GetRemoteLoginEndpoint", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Gets the status of whether a title is enabled for the multiplayer server feature.
        /// </summary>
        public static void GetTitleEnabledForMultiplayerServersStatus(GetTitleEnabledForMultiplayerServersStatusRequest request, Action<GetTitleEnabledForMultiplayerServersStatusResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/GetTitleEnabledForMultiplayerServersStatus", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Join a matchmaking ticket.
        /// </summary>
        public static void JoinMatchmakingTicket(JoinMatchmakingTicketRequest request, Action<JoinMatchmakingTicketResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/JoinMatchmakingTicket", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists archived multiplayer server sessions for a build.
        /// </summary>
        public static void ListArchivedMultiplayerServers(ListMultiplayerServersRequest request, Action<ListMultiplayerServersResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ListArchivedMultiplayerServers", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists multiplayer server game assets for a title.
        /// </summary>
        public static void ListAssetSummaries(ListAssetSummariesRequest request, Action<ListAssetSummariesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ListAssetSummaries", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists summarized details of all multiplayer server builds for a title.
        /// </summary>
        public static void ListBuildSummaries(ListBuildSummariesRequest request, Action<ListBuildSummariesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ListBuildSummaries", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists multiplayer server game certificates for a title.
        /// </summary>
        public static void ListCertificateSummaries(ListCertificateSummariesRequest request, Action<ListCertificateSummariesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ListCertificateSummaries", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists custom container images for a title.
        /// </summary>
        public static void ListContainerImages(ListContainerImagesRequest request, Action<ListContainerImagesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ListContainerImages", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists the tags for a custom container image.
        /// </summary>
        public static void ListContainerImageTags(ListContainerImageTagsRequest request, Action<ListContainerImageTagsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ListContainerImageTags", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// List all matchmaking queue configs.
        /// </summary>
        public static void ListMatchmakingQueues(ListMatchmakingQueuesRequest request, Action<ListMatchmakingQueuesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/ListMatchmakingQueues", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// List all matchmaking ticket Ids the user is a member of.
        /// </summary>
        public static void ListMatchmakingTicketsForPlayer(ListMatchmakingTicketsForPlayerRequest request, Action<ListMatchmakingTicketsForPlayerResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/ListMatchmakingTicketsForPlayer", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists multiplayer server sessions for a build.
        /// </summary>
        public static void ListMultiplayerServers(ListMultiplayerServersRequest request, Action<ListMultiplayerServersResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ListMultiplayerServers", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists quality of service servers.
        /// </summary>
        public static void ListQosServers(ListQosServersRequest request, Action<ListQosServersResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ListQosServers", request, AuthType.None, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Lists virtual machines for a title.
        /// </summary>
        public static void ListVirtualMachineSummaries(ListVirtualMachineSummariesRequest request, Action<ListVirtualMachineSummariesResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ListVirtualMachineSummaries", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Remove a matchmaking queue config.
        /// </summary>
        public static void RemoveMatchmakingQueue(RemoveMatchmakingQueueRequest request, Action<RemoveMatchmakingQueueResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/RemoveMatchmakingQueue", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Request a multiplayer server session. Accepts tokens for title and if game client accesss is enabled, allows game client
        /// to request a server with player entity token.
        /// </summary>
        public static void RequestMultiplayerServer(RequestMultiplayerServerRequest request, Action<RequestMultiplayerServerResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/RequestMultiplayerServer", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Request a party session.
        /// </summary>
        public static void RequestParty(RequestPartyRequest request, Action<RequestPartyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Party/RequestParty", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Rolls over the credentials to the container registry.
        /// </summary>
        public static void RolloverContainerRegistryCredentials(RolloverContainerRegistryCredentialsRequest request, Action<RolloverContainerRegistryCredentialsResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/RolloverContainerRegistryCredentials", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Create or update a matchmaking queue configuration.
        /// </summary>
        public static void SetMatchmakingQueue(SetMatchmakingQueueRequest request, Action<SetMatchmakingQueueResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/Match/SetMatchmakingQueue", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Shuts down a multiplayer server session.
        /// </summary>
        public static void ShutdownMultiplayerServer(ShutdownMultiplayerServerRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/ShutdownMultiplayerServer", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Updates a multiplayer server build's regions.
        /// </summary>
        public static void UpdateBuildRegions(UpdateBuildRegionsRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/UpdateBuildRegions", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }

        /// <summary>
        /// Uploads a multiplayer server game certificate.
        /// </summary>
        public static void UploadCertificate(UploadCertificateRequest request, Action<EmptyResponse> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {


            PlayFabHttp.MakeApiCall("/MultiplayerServer/UploadCertificate", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders);
        }


    }
}
#endif
