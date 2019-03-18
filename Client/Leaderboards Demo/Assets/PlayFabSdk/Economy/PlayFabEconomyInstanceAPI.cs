#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.EconomyModels;
using PlayFab.Internal;
using PlayFab.Json;
using PlayFab.Public;

namespace PlayFab
{
    /// <summary>
    /// API methods for managing User Generated Content. API methods for managing the catalog. Inventory manages in-game assets
    /// for any given entity.
    /// </summary>
    public class PlayFabEconomyInstanceAPI
    {
        public PlayFabApiSettings ApiSettings = null;
        private PlayFabAuthenticationContext authenticationContext = null;

        public PlayFabEconomyInstanceAPI() {}

        public PlayFabEconomyInstanceAPI(PlayFabApiSettings settings) 
        {
            ApiSettings = settings;
        }

        public PlayFabEconomyInstanceAPI(PlayFabAuthenticationContext context) 
        {
            authenticationContext = context;
        }

        public PlayFabEconomyInstanceAPI(PlayFabApiSettings settings, PlayFabAuthenticationContext context) 
        {
            ApiSettings = settings;
            authenticationContext = context;
        }

        public void SetAuthenticationContext(PlayFabAuthenticationContext context)
        {
            authenticationContext = context;
        }

        public PlayFabAuthenticationContext GetAuthenticationContext()
        {
            return authenticationContext;
        }




        /// <summary>
        /// Clear the Client SessionToken which allows this Client to call API calls requiring login.
        /// A new/fresh login will be required after calling this.
        /// </summary>
        public void ForgetAllCredentials()
        {
            if(authenticationContext != null)
            {
                authenticationContext.ForgetAllCredentials();
            }
        }

        /// <summary>
        /// Increase virtual currencies amount.
        /// </summary>

        public void AddVirtualCurrencies(AddVirtualCurrenciesRequest request, Action<AddVirtualCurrenciesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/AddVirtualCurrencies", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Check the status of a transfer all request
        /// </summary>

        public void CheckTransferAllStatus(CheckTransferStatusRequest request, Action<TransferAllResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/CheckTransferAllStatus", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Consume inventory items.
        /// </summary>

        public void ConsumeInventoryItems(ConsumeInventoryItemsRequest request, Action<ConsumeInventoryItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/ConsumeInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Create a bundle
        /// </summary>

        public void CreateBundle(CreateBundleRequest request, Action<CreateBundleResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/CreateBundle", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Creates a new item in the working catalog using provided metadata.
        /// </summary>

        public void CreateDraftItem(CreateDraftItemRequest request, Action<CreateDraftItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/CreateDraftItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Creates a new community catalog item in the working catalog using provided metadata.
        /// </summary>

        public void CreateDraftUgcItem(CreateDraftItemRequest request, Action<CreateDraftItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/CreateDraftUgcItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Creates or updates a review for the specified User Generated Content.
        /// </summary>

        public void CreateOrUpdateReview(CreateOrUpdateReviewRequest request, Action<CreateOrUpdateReviewResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/CreateOrUpdateReview", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Create a store
        /// </summary>

        public void CreateStore(CreateStoreRequest request, Action<CreateStoreResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/CreateStore", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Create a subscription
        /// </summary>

        public void CreateSubscription(CreateSubscriptionRequest request, Action<CreateSubscriptionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/CreateSubscription", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Creates one or more upload URLs which can be used by the client to upload raw mod file data.
        /// </summary>

        public void CreateUgcUploadUrls(CreateUploadUrlsRequest request, Action<CreateUploadUrlsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/CreateUgcUploadUrls", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Creates one or more upload URLs which can be used by the client to upload raw file data.
        /// </summary>

        public void CreateUploadUrls(CreateUploadUrlsRequest request, Action<CreateUploadUrlsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/CreateUploadUrls", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Delete a bundle by friendly Id
        /// </summary>

        public void DeleteBundleByFriendlyId(DeleteBundleByFriendlyIdRequest request, Action<DeleteBundleResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/DeleteBundleByFriendlyId", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Delete a bundle by Id
        /// </summary>

        public void DeleteBundleById(DeleteBundleByIdRequest request, Action<DeleteBundleResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/DeleteBundleById", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Removes an item from working catalog and all published versions from the public catalog.
        /// </summary>

        public void DeleteItem(DeleteItemRequest request, Action<DeleteItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/DeleteItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Delete a store by friendly Id
        /// </summary>

        public void DeleteStoreByFriendlyId(DeleteStoreByFriendlyIdRequest request, Action<DeleteStoreResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/DeleteStoreByFriendlyId", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Delete a store by Id
        /// </summary>

        public void DeleteStoreById(DeleteStoreByIdRequest request, Action<DeleteStoreResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/DeleteStoreById", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Delete a subscription by friendly Id
        /// </summary>

        public void DeleteSubscriptionByFriendlyId(DeleteSubscriptionByFriendlyIdRequest request, Action<DeleteSubscriptionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/DeleteSubscriptionByFriendlyId", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Delete a subscription by Id
        /// </summary>

        public void DeleteSubscriptionById(DeleteSubscriptionByIdRequest request, Action<DeleteSubscriptionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/DeleteSubscriptionById", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Removes an item from working catalog and all published versions from the public catalog.
        /// </summary>

        public void DeleteUgcItem(DeleteItemRequest request, Action<DeleteItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/DeleteUgcItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a bundle by Friendly Id
        /// </summary>

        public void GetBundleByFriendlyId(GetBundleByFriendlyIdRequest request, Action<GetBundleResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetBundleByFriendlyId", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a bundle by Id
        /// </summary>

        public void GetBundleById(GetBundleByIdRequest request, Action<GetBundleResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetBundleById", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a bundle by marketplace offer Id
        /// </summary>

        public void GetBundleByMarketplaceOfferId(GetBundleByMarketplaceOfferIdRequest request, Action<GetBundleResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetBundleByMarketplaceOfferId", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Retrieves an item from the working catalog. This item represents the current working state of the catalog item.
        /// </summary>

        public void GetDraftItem(GetDraftItemRequest request, Action<GetDraftItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetDraftItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Retrieves a paginated list of the items from the draft catalog.
        /// </summary>

        public void GetDraftItems(GetDraftItemsRequest request, Action<GetDraftItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetDraftItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Retrieves an item from the working catalog. This item represents the current working state of the community item.
        /// </summary>

        public void GetDraftUgcItem(GetDraftItemRequest request, Action<GetDraftItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/GetDraftUgcItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Retrieves a paginated list of the items created by a user.
        /// </summary>

        public void GetDraftUgcItems(GetDraftItemsRequest request, Action<GetDraftItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/GetDraftUgcItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get current inventory items.
        /// </summary>

        public void GetInventoryItems(GetInventoryItemsRequest request, Action<GetInventoryItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/GetInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a paginated set of reviews associated with the specified User Generated Content.
        /// </summary>

        public void GetItemReviews(GetReviewsRequest request, Action<GetReviewsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/GetItemReviews", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a summary of all reviews associated with the specified User Generated Content.
        /// </summary>

        public void GetItemReviewSummary(ReviewSummaryRequest request, Action<ReviewSummaryResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/GetItemReviewSummary", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Gets the submitted review for the specifed item by the authenticated user.
        /// </summary>

        public void GetMyReview(GetMyReviewRequest request, Action<GetMyReviewResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/GetMyReview", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Retrieves an item from the public catalog.
        /// </summary>

        public void GetPublishedItem(GetPublishedItemRequest request, Action<GetPublishedItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetPublishedItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Retrieves an item from the public catalog.
        /// </summary>

        public void GetPublishedUgcItem(GetPublishedItemRequest request, Action<GetPublishedItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/GetPublishedUgcItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Gets the status of a publish of an item.
        /// </summary>

        public void GetPublishStatus(PublishStatusRequest request, Action<PublishStatusResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetPublishStatus", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a store by Friendly Id
        /// </summary>

        public void GetStoreByFriendlyId(GetStoreByFriendlyIdRequest request, Action<GetStoreResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetStoreByFriendlyId", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a store by Id
        /// </summary>

        public void GetStoreById(GetStoreByIdRequest request, Action<GetStoreResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetStoreById", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a subscription by Friendly Id
        /// </summary>

        public void GetSubscriptionByFriendlyId(GetSubscriptionByFriendlyIdRequest request, Action<GetSubscriptionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetSubscriptionByFriendlyId", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a subscription by Id
        /// </summary>

        public void GetSubscriptionById(GetSubscriptionByIdRequest request, Action<GetSubscriptionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetSubscriptionById", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get a subscription by marketplace offer Id
        /// </summary>

        public void GetSubscriptionByMarketplaceOfferId(GetSubscriptionByMarketplaceOfferIdRequest request, Action<GetSubscriptionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/GetSubscriptionByMarketplaceOfferId", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Gets the configuration for the user generated content catalog.
        /// </summary>

        public void GetUgcConfig(GetConfigRequest request, Action<GetConfigResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/GetUgcConfig", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Gets the status of a publish of an item.
        /// </summary>

        public void GetUgcPublishStatus(PublishStatusRequest request, Action<PublishStatusResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/GetUgcPublishStatus", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Get current virtual currencies.
        /// </summary>

        public void GetVirtualCurrencies(GetVirtualCurrenciesRequest request, Action<GetVirtualCurrenciesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/GetVirtualCurrencies", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Grant inventory items.
        /// </summary>

        public void GrantInventoryItems(GrantInventoryItemsRequest request, Action<GrantInventoryItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/GrantInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Initiates a publish of an item from the working catalog to the public catalog.
        /// </summary>

        public void PublishItem(PublishItemRequest request, Action<PublishItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/PublishItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Initiates a publish of a item from the working catalog to the public catalog.
        /// </summary>

        public void PublishUgcItem(PublishItemRequest request, Action<PublishItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/PublishUgcItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Purchase an item, bundle or subscription by friendly id.
        /// </summary>

        public void PurchaseItemByFriendlyId(PurchaseItemByFriendlyIdRequest request, Action<PurchaseItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/PurchaseItemByFriendlyId", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Purchase an item, bundle or subscription by id.
        /// </summary>

        public void PurchaseItemById(PurchaseItemByIdRequest request, Action<PurchaseItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/PurchaseItemById", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Execute a search against the public catalog using the provided search parameters and returns a set of paginated results.
        /// </summary>

        public void Search(CatalogSearchRequest request, Action<CatalogSearchResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/Search", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Execute a search against the set of all bundles, using the provided search parameters and returns a set of paginated
        /// results
        /// </summary>

        public void SearchBundles(SearchBundlesRequest request, Action<SearchBundlesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/SearchBundles", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Execute a search against the set of all stores, using the provided search parameters and returns a set of paginated
        /// results
        /// </summary>

        public void SearchStores(SearchStoresRequest request, Action<SearchStoresResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/SearchStores", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Execute a search against the set of all subscriptions, using the provided search parameters and returns a set of
        /// paginated results
        /// </summary>

        public void SearchSubscriptions(SearchSubscriptionsRequest request, Action<SearchSubscriptionsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/SearchSubscriptions", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Set inventory items
        /// </summary>

        public void SetInventoryItems(SetInventoryItemsRequest request, Action<SetInventoryItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/SetInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Gets the configuration for the user generated content catalog.
        /// </summary>

        public void SetUgcConfig(SetConfigRequest request, Action<SetConfigResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/SetUgcConfig", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Set virtual currencies
        /// </summary>

        public void SetVirtualCurrencies(SetVirtualCurrenciesRequest request, Action<SetVirtualCurrenciesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/SetVirtualCurrencies", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Submit a vote for a review, indicating whether the review was helpful or unhelpful.
        /// </summary>

        public void SubmitHelpfulnessVote(HelpfulnessVoteRequest request, Action<HelpfulnessVoteResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/SubmitHelpfulnessVote", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Decrease virtual currencies amount.
        /// </summary>

        public void SubtractVirtualCurrencies(SubtractVirtualCurrenciesRequest request, Action<SubtractVirtualCurrenciesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/SubtractVirtualCurrencies", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Transfer all assets
        /// </summary>

        public void TransferAll(TransferAllRequest request, Action<TransferAllResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/TransferAll", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Transfer inventory items.
        /// </summary>

        public void TransferInventoryItems(TransferInventoryItemsRequest request, Action<TransferInventoryItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/TransferInventoryItems", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Transfer virtual currencies.
        /// </summary>

        public void TransferVirtualCurrencies(TransferVirtualCurrenciesRequest request, Action<TransferVirtualCurrenciesResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/TransferVirtualCurrencies", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Update a bundle
        /// </summary>

        public void UpdateBundle(UpdateBundleRequest request, Action<UpdateBundleResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/UpdateBundle", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Update the metadata for an item in the working catalog.
        /// </summary>

        public void UpdateDraftItem(UpdateDraftItemRequest request, Action<UpdateDraftItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/UpdateDraftItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Update the metadata for an item in the working catalog.
        /// </summary>

        public void UpdateDraftUgcItem(UpdateDraftItemRequest request, Action<UpdateDraftItemResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/UserGeneratedContent/UpdateDraftUgcItem", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Update inventory Items.
        /// </summary>

        public void UpdateInventoryItemsProperties(UpdateInventoryItemsPropertiesRequest request, Action<UpdateInventoryPropertiesItemsResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Inventory/UpdateInventoryItemsProperties", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Update a store
        /// </summary>

        public void UpdateStore(UpdateStoreRequest request, Action<UpdateStoreResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/UpdateStore", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 
        /// <summary>
        /// Update a subscription
        /// </summary>

        public void UpdateSubscription(UpdateSubscriptionRequest request, Action<UpdateSubscriptionResult> resultCallback, Action<PlayFabError> errorCallback, object customData = null, Dictionary<string, string> extraHeaders = null)
        {
            PlayFabHttp.MakeApiCall("/Catalog/UpdateSubscription", request, AuthType.EntityToken, resultCallback, errorCallback, customData, extraHeaders, false, authenticationContext, ApiSettings);
        } 

    }
}
#endif
