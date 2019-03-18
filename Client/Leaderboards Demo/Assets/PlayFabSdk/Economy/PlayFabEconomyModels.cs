#if !DISABLE_PLAYFABENTITY_API
using System;
using System.Collections.Generic;
using PlayFab.SharedModels;

namespace PlayFab.EconomyModels
{
    public enum AccessPolicy
    {
        Closed,
        Open
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will increase the entity's currencies by a specific
    /// amount.
    /// </summary>
    [Serializable]
    public class AddVirtualCurrenciesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A list of currencies to modify
        /// </summary>
        public List<CurrencyDetails> Currencies;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class AddVirtualCurrenciesResult : PlayFabResultCommon
    {
        public List<CurrencyResponseDto> Currencies;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class CatalogAlternateId
    {
        /// <summary>
        /// Type of the alternate Id
        /// </summary>
        public string Type;
        /// <summary>
        /// Value of the alternate Id
        /// </summary>
        public string Value;
    }

    [Serializable]
    public class CatalogItemMetadata
    {
        /// <summary>
        /// The alternate IDs associated with this item.
        /// </summary>
        public List<CatalogAlternateId> AlternateIds;
        /// <summary>
        /// The set of contents associated with this item.
        /// </summary>
        public List<Content> Contents;
        /// <summary>
        /// The client-defined type of the item.
        /// </summary>
        public string ContentType;
        /// <summary>
        /// The date and time when this item was created.
        /// </summary>
        public DateTime? CreationDate;
        /// <summary>
        /// The ID of the creator of this catalog item.
        /// </summary>
        public EntityKey CreatorEntityKey;
        /// <summary>
        /// A dictionary of localized descriptions. Key is language code and localized string is the value. The neutral locale is
        /// required.
        /// </summary>
        public Dictionary<string,string> Description;
        /// <summary>
        /// Game specific properties for display purposes. This is an arbitrary JSON blob.
        /// </summary>
        public object DisplayProperties;
        public string DisplayVersion;
        /// <summary>
        /// The current ETag value that can be used for optimistic concurrency in the If-None-Match header.
        /// </summary>
        public string ETag;
        /// <summary>
        /// The unique ID of the catalog item.
        /// </summary>
        public string Id;
        /// <summary>
        /// The images associated with this item. Images can be thumbnails or screenshots.
        /// </summary>
        public List<Image> Images;
        /// <summary>
        /// Indicates if the item is hidden
        /// </summary>
        public bool? IsHidden;
        /// <summary>
        /// The item references associated with this item.
        /// </summary>
        public List<CatalogItemReference> ItemReferences;
        /// <summary>
        /// The date and time this item was last updated.
        /// </summary>
        public DateTime? LastModifiedDate;
        /// <summary>
        /// The platforms supported by this item.
        /// </summary>
        public List<string> Platforms;
        /// <summary>
        /// The date of when the item will be available. If not provided then the product will appear immediately.
        /// </summary>
        public DateTime? StartDate;
        /// <summary>
        /// The list of tags that are associated with this item.
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// A dictionary of localized titles. Key is language code and localized string is the value. The neutral locale is
        /// required.
        /// </summary>
        public Dictionary<string,string> Title;
    }

    [Serializable]
    public class CatalogItemReference
    {
        /// <summary>
        /// The amount of the catalog item.
        /// </summary>
        public int? Amount;
        /// <summary>
        /// The unique ID of the catalog item.
        /// </summary>
        public string Id;
        /// <summary>
        /// The price of the catalog item.
        /// </summary>
        public CatalogPrice Price;
    }

    [Serializable]
    public class CatalogPrice
    {
        /// <summary>
        /// Prices of the catalog item.
        /// </summary>
        public List<CatalogPriceInstance> Prices;
        /// <summary>
        /// Sort setting of the catalog item.
        /// </summary>
        public int? Sort;
    }

    [Serializable]
    public class CatalogPriceAmount
    {
        /// <summary>
        /// The amount of the catalog price.
        /// </summary>
        public int Amount;
        /// <summary>
        /// The currency ID of the catalog price.
        /// </summary>
        public string CurrencyId;
    }

    [Serializable]
    public class CatalogPriceInstance
    {
        /// <summary>
        /// The amounts of the catalog item price.
        /// </summary>
        public List<CatalogPriceAmount> Amounts;
    }

    [Serializable]
    public class CatalogSearchRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// An OData filter used to refine the search query.
        /// </summary>
        public string Filter;
        /// <summary>
        /// An OData orderBy used to order the results of the search query.
        /// </summary>
        public string OrderBy;
        /// <summary>
        /// The text to search for.
        /// </summary>
        public string Search;
        /// <summary>
        /// An OData select query option used to augment the search results. If not defined, the default search result metadata will
        /// be returned.
        /// </summary>
        public string Select;
        /// <summary>
        /// The number of results to skip.
        /// </summary>
        public int Skip;
        /// <summary>
        /// The ID of the title that this catalog item is associated with.
        /// </summary>
        public string TitleId;
        /// <summary>
        /// The number of results to retrieve.
        /// </summary>
        public int Top;
    }

    [Serializable]
    public class CatalogSearchResult : PlayFabResultCommon
    {
        /// <summary>
        /// The total count of hits for the search query.
        /// </summary>
        public int? Count;
        /// <summary>
        /// The paginated set of results for the search query.
        /// </summary>
        public List<CatalogItemMetadata> Items;
    }

    /// <summary>
    /// Check the status of a transfer all with a transfer ticket Id
    /// </summary>
    [Serializable]
    public class CheckTransferStatusRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The id of the transfer all request ticket that was returned on a TransferAllRequest
        /// </summary>
        public string TransferTicketId;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will consume the specified inventory items.
    /// </summary>
    [Serializable]
    public class ConsumeInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// A list of Items to modify
        /// </summary>
        public List<InventoryItemDetails> Items;
    }

    [Serializable]
    public class ConsumeInventoryItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<InventoryItemResponseDto> Items;
    }

    [Serializable]
    public class Content
    {
        public string Id;
        /// <summary>
        /// The maximum client version that this content is compatible with.
        /// </summary>
        public string MaxClientVersion;
        /// <summary>
        /// The minimum client version that this content is compatible with.
        /// </summary>
        public string MinClientVersion;
        /// <summary>
        /// The list of tags that are associated with this content.
        /// </summary>
        public List<string> Tags;
        /// <summary>
        /// The client-defined type of the content.
        /// </summary>
        public string Type;
        /// <summary>
        /// The Azure CDN URL for retrieval of the catalog item binary content.
        /// </summary>
        public string Url;
    }

    /// <summary>
    /// Create bundle request
    /// </summary>
    [Serializable]
    public class CreateBundleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Bundle details
        /// </summary>
        public CatalogItemMetadata Bundle;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Create bundle result
    /// </summary>
    [Serializable]
    public class CreateBundleResult : PlayFabResultCommon
    {
        public CatalogItemMetadata Bundle;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// The item will not be published to the public catalog until the user makes a call to the PublishItem API.
    /// </summary>
    [Serializable]
    public class CreateDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Metadata describing the new catalog item to be created.
        /// </summary>
        public CatalogItemMetadata Item;
    }

    [Serializable]
    public class CreateDraftItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Updated metadata describing the catalog item just created.
        /// </summary>
        public CatalogItemMetadata Item;
    }

    [Serializable]
    public class CreateOrUpdateReviewRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The ID of the item to submit a review for.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The review to submit.
        /// </summary>
        public Review Review;
    }

    [Serializable]
    public class CreateOrUpdateReviewResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Create store request
    /// </summary>
    [Serializable]
    public class CreateStoreRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// Store details
        /// </summary>
        public CatalogItemMetadata Store;
    }

    /// <summary>
    /// Create store result
    /// </summary>
    [Serializable]
    public class CreateStoreResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public CatalogItemMetadata Store;
    }

    /// <summary>
    /// Create subscription request
    /// </summary>
    [Serializable]
    public class CreateSubscriptionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// Subscription details
        /// </summary>
        public CatalogItemMetadata Subscription;
    }

    /// <summary>
    /// Create subscription result
    /// </summary>
    [Serializable]
    public class CreateSubscriptionResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public CatalogItemMetadata Subscription;
    }

    /// <summary>
    /// Upload URLs point to Azure Blobs; clients must follow the Microsoft Azure Storage Blob Service REST
    /// API pattern for uploading content. The response contains upload URLs and IDs for each file. The IDs and
    /// URLs
    /// returned must be added to the item metadata and commited using the CreateDraftItem or UpdateDraftItem
    /// Item APIs.
    /// </summary>
    [Serializable]
    public class CreateUploadUrlsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Description of the files to be uploaded by the client.
        /// </summary>
        public List<UploadInfo> Files;
    }

    [Serializable]
    public class CreateUploadUrlsResult : PlayFabResultCommon
    {
        /// <summary>
        /// Urls and metadata for the files to be uploaded by the client.
        /// </summary>
        public List<UploadUrlMetadata> UploadUrls;
    }

    [Serializable]
    public class CurrencyDetails
    {
        public int Amount;
        public string InstanceId;
        public string Name;
    }

    [Serializable]
    public class CurrencyResponseDto
    {
        public int Amount;
        public int? ChangedAmount;
        public string Name;
    }

    /// <summary>
    /// Delete bundle by friendly Id request
    /// </summary>
    [Serializable]
    public class DeleteBundleByFriendlyIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The friendly Id of target bundle.
        /// </summary>
        public string FriendlyId;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Delete bundle by Id request
    /// </summary>
    [Serializable]
    public class DeleteBundleByIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Id of target bundle
        /// </summary>
        public string Id;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Delete bundle result
    /// </summary>
    [Serializable]
    public class DeleteBundleResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class DeleteItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ID of the catalog item to delete.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class DeleteItemResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Delete store by Friendly Id request
    /// </summary>
    [Serializable]
    public class DeleteStoreByFriendlyIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The friendly Id of target store.
        /// </summary>
        public string FriendlyId;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Delete store by Id request
    /// </summary>
    [Serializable]
    public class DeleteStoreByIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Id of target store
        /// </summary>
        public string Id;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Delete store result
    /// </summary>
    [Serializable]
    public class DeleteStoreResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Delete Subscription by friendly Id request
    /// </summary>
    [Serializable]
    public class DeleteSubscriptionByFriendlyIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The friendly Id of target bundle.
        /// </summary>
        public string FriendlyId;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Delete subscription by Id request
    /// </summary>
    [Serializable]
    public class DeleteSubscriptionByIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Id of target subscription
        /// </summary>
        public string Id;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Delete subscription result
    /// </summary>
    [Serializable]
    public class DeleteSubscriptionResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Combined entity type and ID structure which uniquely identifies a single entity.
    /// </summary>
    [Serializable]
    public class EntityKey
    {
        /// <summary>
        /// Unique ID of the entity.
        /// </summary>
        public string Id;
        /// <summary>
        /// Entity type. See https://api.playfab.com/docs/tutorials/entities/entitytypes
        /// </summary>
        public string Type;
    }

    /// <summary>
    /// Get bundle by friendly Id request
    /// </summary>
    [Serializable]
    public class GetBundleByFriendlyIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether to expand the referenced items
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// The friendly Id of target bundle.
        /// </summary>
        public string FriendlyId;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Get bundle by Id request
    /// </summary>
    [Serializable]
    public class GetBundleByIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether to expand the referenced items
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// Id of target bundle
        /// </summary>
        public string Id;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Get bundle by marketplace offer Id request
    /// </summary>
    [Serializable]
    public class GetBundleByMarketplaceOfferIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether to expand the referenced items
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The Marketplace offer Id of target bundle.
        /// </summary>
        public CatalogAlternateId MarketplaceOfferId;
    }

    /// <summary>
    /// Get bundle result
    /// </summary>
    [Serializable]
    public class GetBundleResult : PlayFabResultCommon
    {
        public CatalogItemMetadata Bundle;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<CatalogItemMetadata> ReferencedItems;
    }

    [Serializable]
    public class GetConfigRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetConfigResult : PlayFabResultCommon
    {
        public UserGeneratedContentConfig Config;
    }

    [Serializable]
    public class GetDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ID of the catalog item to retrieve from the working catalog.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class GetDraftItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Full metadata of the catalog item requested.
        /// </summary>
        public CatalogItemMetadata Item;
    }

    [Serializable]
    public class GetDraftItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items created by the caller, if any are available. Should be null on
        /// initial request.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// Number of items to retrieve. Maximum page size is 10.
        /// </summary>
        public int Count;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class GetDraftItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of items, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// The total number of items created by the caller.
        /// </summary>
        public int Count;
        /// <summary>
        /// A set of items created by the caller.
        /// </summary>
        public List<CatalogItemMetadata> Items;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will get the entity's inventory items.
    /// </summary>
    [Serializable]
    public class GetInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class GetInventoryItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<InventoryItemResponseDto> Items;
        public List<SubscriptionItemResponseDto> Subscriptions;
    }

    [Serializable]
    public class GetMyReviewRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The ID of the item to retrieve the user's review for.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class GetMyReviewResult : PlayFabResultCommon
    {
        /// <summary>
        /// The review the user submitted for the requested item.
        /// </summary>
        public Review Review;
    }

    [Serializable]
    public class GetPublishedItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ID of the catalog item to retrieve from the working catalog.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class GetPublishedItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Full metadata of the catalog item requested.
        /// </summary>
        public CatalogItemMetadata Item;
    }

    [Serializable]
    public class GetReviewsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The ID of the item to retrieve reviews for.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// An OData orderBy used to order the results of the query.
        /// </summary>
        public string OrderBy;
        /// <summary>
        /// The number of review results to skip. If not specified, defaults to 0.
        /// </summary>
        public int Skip;
        /// <summary>
        /// The number of review results to retrieve. If not specified, defaults to 10.
        /// </summary>
        public int Top;
    }

    [Serializable]
    public class GetReviewsResult : PlayFabResultCommon
    {
        /// <summary>
        /// An opaque token used to retrieve the next page of reviews, if any are available.
        /// </summary>
        public string ContinuationToken;
        /// <summary>
        /// The total number of reviews associated with this item.
        /// </summary>
        public int Count;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The paginated set of results.
        /// </summary>
        public List<Review> Reviews;
    }

    /// <summary>
    /// Get store by friendly Id request
    /// </summary>
    [Serializable]
    public class GetStoreByFriendlyIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether to expand the referenced items
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// The friendly Id of target store.
        /// </summary>
        public string FriendlyId;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Get store by Id request
    /// </summary>
    [Serializable]
    public class GetStoreByIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether to expand the referenced items
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// Id of target store
        /// </summary>
        public string Id;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Get store result
    /// </summary>
    [Serializable]
    public class GetStoreResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<CatalogItemMetadata> ReferencedItems;
        public CatalogItemMetadata Store;
    }

    /// <summary>
    /// Get subscription by friendly Id request
    /// </summary>
    [Serializable]
    public class GetSubscriptionByFriendlyIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether to expand the referenced items
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// The friendly Id of target subscription.
        /// </summary>
        public string FriendlyId;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Get subscription by Id request
    /// </summary>
    [Serializable]
    public class GetSubscriptionByIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether to expand the referenced items
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// Id of target subscription
        /// </summary>
        public string Id;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Get subscription by marketplace offer Id request
    /// </summary>
    [Serializable]
    public class GetSubscriptionByMarketplaceOfferIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether to expand the referenced items
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The Marketplace offer Id of target bundle.
        /// </summary>
        public CatalogAlternateId MarketplaceOfferId;
    }

    /// <summary>
    /// Get subscription result
    /// </summary>
    [Serializable]
    public class GetSubscriptionResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<CatalogItemMetadata> ReferencedItems;
        public CatalogItemMetadata Subscription;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will get the entity's virtual currencies.
    /// </summary>
    [Serializable]
    public class GetVirtualCurrenciesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class GetVirtualCurrenciesResult : PlayFabResultCommon
    {
        public List<CurrencyResponseDto> Currencies;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will grant the specified inventory items.
    /// </summary>
    [Serializable]
    public class GrantInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// A list of Items to modify
        /// </summary>
        public List<InventoryItemDetails> Items;
    }

    [Serializable]
    public class GrantInventoryItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<InventoryItemResponseDto> Items;
    }

    [Serializable]
    public class HelpfulnessVoteRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        public bool IsHelpful;
        /// <summary>
        /// The ID of the review to submit a helpfulness vote for.
        /// </summary>
        public string ReviewId;
    }

    [Serializable]
    public class HelpfulnessVoteResult : PlayFabResultCommon
    {
    }

    [Serializable]
    public class Image
    {
        public string Id;
        /// <summary>
        /// The optional list of locales that are supported by this image.
        /// </summary>
        public List<string> Locales;
        /// <summary>
        /// The client-defined tag associated with this image.
        /// </summary>
        public string Tag;
        /// <summary>
        /// The client-defined type of this image.
        /// </summary>
        public string Type;
        /// <summary>
        /// The URL for retrieval of the image.
        /// </summary>
        public string Url;
    }

    [Serializable]
    public class InventoryItemDetails
    {
        public string Duration;
        public DateTime ExpirationDate;
        public string InstanceId;
        public bool isSubscription;
        public string Marketplace;
        public string Name;
        public string Origin;
        public string OriginId;
        public Dictionary<string,string> Properties;
        public int Quantity;
    }

    [Serializable]
    public class InventoryItemResponseDto
    {
        public int Amount;
        public int? ChangedAmount;
        public string InstanceId;
        public string Name;
        public Dictionary<string,string> Properties;
    }

    /// <summary>
    /// The call kicks off a workflow to publish the item to the public catalog.
    /// The Publish Status API should be used to monitor the publish job.
    /// </summary>
    [Serializable]
    public class PublishItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ETag of the catalog item to published from the working catalog to the public catalog. Used for optimistic concurrency.
        /// If the provided ETag does not match the ETag in the current working catalog, the request will be reject. If not
        /// provided, the current version of the document in the working catalog will be published.
        /// </summary>
        public string ETag;
        /// <summary>
        /// ID of the catalog item to publish from the working catalog to the public catalog.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class PublishItemResult : PlayFabResultCommon
    {
    }

    public enum PublishResult
    {
        Unknown,
        Pending,
        Succeeded,
        Failed,
        Canceled
    }

    [Serializable]
    public class PublishStatusRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// ID of the catalog item to publish from the working catalog to the public catalog.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class PublishStatusResult : PlayFabResultCommon
    {
        /// <summary>
        /// High level state of the publish.
        /// </summary>
        public PublishResult? Result;
        /// <summary>
        /// Descriptive message about the current status of the publish.
        /// </summary>
        public string StatusMessage;
    }

    /// <summary>
    /// Purchase item by friendly Id request
    /// </summary>
    [Serializable]
    public class PurchaseItemByFriendlyIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The currencies used to pay for item.
        /// </summary>
        public List<PurchaseItemCurrency> Currencies;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// Friendly identifier of the item to purchase.
        /// </summary>
        public string ItemFriendlyId;
        /// <summary>
        /// The store to buy the item through.
        /// </summary>
        public PurchaseStoreInfo Store;
    }

    /// <summary>
    /// Purchase item by Id request
    /// </summary>
    [Serializable]
    public class PurchaseItemByIdRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The currencies used to pay for item.
        /// </summary>
        public List<PurchaseItemCurrency> Currencies;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// Unique identifier of the item to purchase.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The store to buy the item through.
        /// </summary>
        public PurchaseStoreInfo Store;
    }

    [Serializable]
    public class PurchaseItemCurrency
    {
        /// <summary>
        /// The currency code.
        /// </summary>
        public string CurrencyCode;
        /// <summary>
        /// Price the client expects to pay for the item.
        /// </summary>
        public int ExpectedPrice;
    }

    /// <summary>
    /// Purchase item result
    /// </summary>
    [Serializable]
    public class PurchaseItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Details of the currencies used to purchase the items.
        /// </summary>
        public List<PurchaseItemResultCurrency> Currencies;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// Details for the items purchased.
        /// </summary>
        public List<PurchaseItemResultItem> Items;
    }

    [Serializable]
    public class PurchaseItemResultCurrency
    {
        /// <summary>
        /// The total amount of the currency on inventory.
        /// </summary>
        public int Amount;
        /// <summary>
        /// The amount of the currency used in this call.
        /// </summary>
        public int ChangedAmount;
        /// <summary>
        /// The currency code.
        /// </summary>
        public string CurrencyCode;
    }

    [Serializable]
    public class PurchaseItemResultItem
    {
        /// <summary>
        /// The total amount of the item on inventory.
        /// </summary>
        public int Amount;
        /// <summary>
        /// The amount of the item purchased in this call.
        /// </summary>
        public int ChangedAmount;
        /// <summary>
        /// Friendly id of the item.
        /// </summary>
        public string FriendlyId;
        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string InstanceId;
        /// <summary>
        /// Unique identifier of the item.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The type of item.
        /// </summary>
        public PurchaseItemType? ItemType;
    }

    public enum PurchaseItemType
    {
        Item,
        Subscription
    }

    [Serializable]
    public class PurchaseStoreInfo
    {
        /// <summary>
        /// The friendly identifier of the store.
        /// </summary>
        public string FriendlyId;
        /// <summary>
        /// The unique identifier of the store.
        /// </summary>
        public string Id;
    }

    [Serializable]
    public class Review
    {
        public int HelpfulNegative;
        public int HelpfulnessVotes;
        public int HelpfulPositive;
        /// <summary>
        /// Indicates whether the review author has the item installed.
        /// </summary>
        public bool IsInstalled;
        /// <summary>
        /// The ID of the item being reviewed.
        /// </summary>
        public string ItemId;
        /// <summary>
        /// The version of the item being reviewed.
        /// </summary>
        public string ItemVersion;
        public string Locale;
        /// <summary>
        /// Star rating associated with this review.
        /// </summary>
        public int Rating;
        public string ReviewId;
        public string ReviewText;
        /// <summary>
        /// The date and time this review was last submitted.
        /// </summary>
        public DateTime Submitted;
        public string Title;
    }

    [Serializable]
    public class ReviewSummaryRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The ID of the item to retrieve the reviews summary for.
        /// </summary>
        public string ItemId;
    }

    [Serializable]
    public class ReviewSummaryResult : PlayFabResultCommon
    {
        public Review LeastFavorableReview;
        public Review MostFavorableReview;
        /// <summary>
        /// The summary of ratings associated with this item.
        /// </summary>
        public UgcRatings Ratings;
        /// <summary>
        /// The total number of reviews associated with this item.
        /// </summary>
        public int ReviewsCount;
    }

    /// <summary>
    /// Search bundles request
    /// </summary>
    [Serializable]
    public class SearchBundlesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether the referenced items should be expanded.
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// An OData filter used to refine the search query.
        /// </summary>
        public string Filter;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// An OData orderBy used to order the results of the search query.
        /// </summary>
        public string OrderBy;
        /// <summary>
        /// The text to search for
        /// </summary>
        public string Search;
        /// <summary>
        /// The number of search results to skip.
        /// </summary>
        public int Skip;
        /// <summary>
        /// The number of search results to retrieve.
        /// </summary>
        public int Top;
    }

    /// <summary>
    /// Search bundle result
    /// </summary>
    [Serializable]
    public class SearchBundlesResult : PlayFabResultCommon
    {
        public List<GetBundleResult> Bundles;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Search stores request
    /// </summary>
    [Serializable]
    public class SearchStoresRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether the referenced items should be expanded.
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// An OData filter used to refine the search query.
        /// </summary>
        public string Filter;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// An OData orderBy used to order the results of the search query.
        /// </summary>
        public string OrderBy;
        /// <summary>
        /// The text to search for
        /// </summary>
        public string Search;
        /// <summary>
        /// The number of search results to skip.
        /// </summary>
        public int Skip;
        /// <summary>
        /// The number of search results to retrieve.
        /// </summary>
        public int Top;
    }

    /// <summary>
    /// Search store result
    /// </summary>
    [Serializable]
    public class SearchStoresResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<GetStoreResult> Stores;
    }

    /// <summary>
    /// Search subscriptions request
    /// </summary>
    [Serializable]
    public class SearchSubscriptionsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Whether the referenced items should be expanded.
        /// </summary>
        public bool ExpandReferencedItems;
        /// <summary>
        /// An OData filter used to refine the search query.
        /// </summary>
        public string Filter;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// An OData orderBy used to order the results of the search query.
        /// </summary>
        public string OrderBy;
        /// <summary>
        /// The text to search for
        /// </summary>
        public string Search;
        /// <summary>
        /// The number of search results to skip.
        /// </summary>
        public int Skip;
        /// <summary>
        /// The number of search results to retrieve.
        /// </summary>
        public int Top;
    }

    /// <summary>
    /// Search subscription result
    /// </summary>
    [Serializable]
    public class SearchSubscriptionsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<GetSubscriptionResult> Subscriptions;
    }

    [Serializable]
    public class SetConfigRequest : PlayFabRequestCommon
    {
        public UserGeneratedContentConfig Config;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
    }

    [Serializable]
    public class SetConfigResult : PlayFabResultCommon
    {
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will set the entity's inventory items
    /// </summary>
    [Serializable]
    public class SetInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// A list of Items to modify
        /// </summary>
        public List<InventoryItemDetails> Items;
    }

    [Serializable]
    public class SetInventoryItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<InventoryItemResponseDto> Items;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will set the entity's currencies to a specific amount.
    /// </summary>
    [Serializable]
    public class SetVirtualCurrenciesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A list of currencies to modify
        /// </summary>
        public List<CurrencyDetails> Currencies;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class SetVirtualCurrenciesResult : PlayFabResultCommon
    {
        public List<CurrencyResponseDto> Currencies;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class SubscriptionItemResponseDto
    {
        public DateTime? ExpirationDate;
        public List<string> ItemIds;
        public string Marketplace;
        public string OfferId;
    }

    /// <summary>
    /// Given an entity type, entity identifier and container details, will decrease the entity's currencies by a specific
    /// amount.
    /// </summary>
    [Serializable]
    public class SubtractVirtualCurrenciesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A list of currencies to modify
        /// </summary>
        public List<CurrencyDetails> Currencies;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class SubtractVirtualCurrenciesResult : PlayFabResultCommon
    {
        public List<CurrencyResponseDto> Currencies;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Transfer all assets from an entity's container Id to another entity's container Id.
    /// </summary>
    [Serializable]
    public class TransferAllRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to transfer from.
        /// </summary>
        public EntityKey GivingEntity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The beneficiary entity from this action.
        /// </summary>
        public EntityKey ReceivingEntity;
    }

    [Serializable]
    public class TransferAllResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public TransferAllStatus? TransferStatus;
        public string TransferTicketId;
    }

    public enum TransferAllStatus
    {
        Completed,
        InProgress,
        Aborted,
        Unknown
    }

    /// <summary>
    /// Transfer the specified inventory items of an entity's container Id to another entity's container Id.
    /// </summary>
    [Serializable]
    public class TransferInventoryItemsRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to transfer from.
        /// </summary>
        public EntityKey GivingEntity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// A list of Items to transfer
        /// </summary>
        public List<InventoryItemDetails> Items;
        /// <summary>
        /// The beneficiary entity from this action.
        /// </summary>
        public EntityKey ReceivingEntity;
    }

    [Serializable]
    public class TransferInventoryItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Transfer the specified virtual currencies amount of an entity's container Id to another entity's container Id.
    /// </summary>
    [Serializable]
    public class TransferVirtualCurrenciesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// A list of currencies to transfer
        /// </summary>
        public List<CurrencyDetails> Currencies;
        /// <summary>
        /// The entity to transfer from.
        /// </summary>
        public EntityKey GivingEntity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// The beneficiary entity from this action.
        /// </summary>
        public EntityKey ReceivingEntity;
    }

    [Serializable]
    public class TransferVirtualCurrenciesResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class UgcRatings
    {
        /// <summary>
        /// The average rating for this item
        /// </summary>
        public float? Average;
        /// <summary>
        /// The total count of 1 star ratings for this item
        /// </summary>
        public int? Count1Star;
        /// <summary>
        /// The total count of 2 star ratings for this item
        /// </summary>
        public int? Count2Star;
        /// <summary>
        /// The total count of 3 star ratings for this item
        /// </summary>
        public int? Count3Star;
        /// <summary>
        /// The total count of 4 star ratings for this item
        /// </summary>
        public int? Count4Star;
        /// <summary>
        /// The total count of 5 star ratings for this item
        /// </summary>
        public int? Count5Star;
        /// <summary>
        /// The total count of ratings for this item
        /// </summary>
        public int? TotalCount;
    }

    /// <summary>
    /// Update bundle request
    /// </summary>
    [Serializable]
    public class UpdateBundleRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// Bundle details
        /// </summary>
        public CatalogItemMetadata Bundle;
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    /// <summary>
    /// Update bundle result
    /// </summary>
    [Serializable]
    public class UpdateBundleResult : PlayFabResultCommon
    {
        public CatalogItemMetadata Bundle;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
    }

    [Serializable]
    public class UpdateDraftItemRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// Updated metadata describing the catalog item to be updated.
        /// </summary>
        public CatalogItemMetadata Item;
    }

    [Serializable]
    public class UpdateDraftItemResult : PlayFabResultCommon
    {
        /// <summary>
        /// Updated metadata describing the catalog item just updated.
        /// </summary>
        public CatalogItemMetadata Item;
    }

    /// <summary>
    /// Update the specified inventory items.
    /// </summary>
    [Serializable]
    public class UpdateInventoryItemsPropertiesRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// A list of Items to modify
        /// </summary>
        public List<InventoryItemDetails> Items;
    }

    [Serializable]
    public class UpdateInventoryPropertiesItemsResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public List<InventoryItemResponseDto> Items;
        public List<SubscriptionItemResponseDto> Subscriptions;
    }

    /// <summary>
    /// Update store request
    /// </summary>
    [Serializable]
    public class UpdateStoreRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// Bundle details
        /// </summary>
        public CatalogItemMetadata Store;
    }

    /// <summary>
    /// Update store result
    /// </summary>
    [Serializable]
    public class UpdateStoreResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public CatalogItemMetadata Store;
    }

    /// <summary>
    /// Update subscription request
    /// </summary>
    [Serializable]
    public class UpdateSubscriptionRequest : PlayFabRequestCommon
    {
        /// <summary>
        /// The entity to perform this action on.
        /// </summary>
        public EntityKey Entity;
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        /// <summary>
        /// subscription details
        /// </summary>
        public CatalogItemMetadata Subscription;
    }

    /// <summary>
    /// Update subscription result
    /// </summary>
    [Serializable]
    public class UpdateSubscriptionResult : PlayFabResultCommon
    {
        /// <summary>
        /// The Idempotency Id for this request
        /// </summary>
        public string IdempotencyId;
        public CatalogItemMetadata Subscription;
    }

    [Serializable]
    public class UploadInfo
    {
        /// <summary>
        /// Name of the file to be uploaded.
        /// </summary>
        public string FileName;
        /// <summary>
        /// Size of the file to be uploaded, in bytes.
        /// </summary>
        public int FileSize;
    }

    [Serializable]
    public class UploadUrlMetadata
    {
        /// <summary>
        /// Name of the file for which this upload url was requested.
        /// </summary>
        public string FileName;
        /// <summary>
        /// Unique identifier for the binary content to be uploaded to the target url.
        /// </summary>
        public string Id;
        /// <summary>
        /// Url for the binary content to be uploaded to.
        /// </summary>
        public string Url;
    }

    [Serializable]
    public class UserGeneratedContentConfig
    {
        /// <summary>
        /// The set of valid content types.
        /// </summary>
        public List<string> ContentTypes;
        /// <summary>
        /// The policy defining who is allowed to create and manage UGC.
        /// </summary>
        public AccessPolicy? CreatorAccessPolicy;
        /// <summary>
        /// The set of valid tags.
        /// </summary>
        public List<string> Tags;
    }
}
#endif
