using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.ProductCatalogs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems
{
    public class ProductItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("additional_image_cdn_urls")]
        public List<Dictionary<string,string>> AdditionalImageCDNURLs { get; set; } = new List<Dictionary<string,string>>();

        [JsonProperty("additional_image_urls")]
        public List<string> AdditionalImageURLs { get; set; } = new List<string>();

        [JsonProperty("additional_variant_attributes")]
        public Dictionary<string, string> AdditionalVariantAttributes { get; set; } = new Dictionary<string, string>();

        [JsonProperty("age_group")]
        public ProductItemAgeGroup AgeGroup { get; set; }

        [JsonProperty("applinks")]
        public CatalogItemAppLinks Applinks { get; set; }

        [JsonProperty("availability")]
        public ProductItemAvailability Availability { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("capability_to_review_status")]
        public Dictionary<string, ProductItemReviewStatus> CapabilityToReviewStatus { get; set; } = new Dictionary<string, ProductItemReviewStatus>();

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("category_specific_fields")]
        public CatalogSubVerticalList CategorySpecificFields { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("commerce_insights")]
        public ProductItemCommerceInsights CommerceInsights { get; set; }

        [JsonProperty("condition")]
        public ProductItemCondition Condition { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("custom_data")]
        public Dictionary<string, string> CustomData { get; set; } = new Dictionary<string, string>();

        [JsonProperty("custom_label_0")]
        public string CustomLabel0 { get; set; }

        [JsonProperty("custom_label_1")]
        public string CustomLabel1 { get; set; }

        [JsonProperty("custom_label_2")]
        public string CustomLabel2 { get; set; }

        [JsonProperty("custom_label_3")]
        public string CustomLabel3 { get; set; }

        [JsonProperty("custom_label_4")]
        public string CustomLabel4 { get; set; }

        [JsonProperty("custom_number_0")]
        public string CustomNumber0 { get; set; }

        [JsonProperty("custom_number_1")]
        public string CustomNumber1 { get; set; }

        [JsonProperty("custom_number_2")]
        public string CustomNumber2 { get; set; }

        [JsonProperty("custom_number_3")]
        public string CustomNumber3 { get; set; }

        [JsonProperty("custom_number_4")]
        public string CustomNumber4 { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("errors")]
        public List<ProductItemError> Errors { get; set; } = new List<ProductItemError>();

        [JsonProperty("expiration_date")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty("fb_product_category")]
        public string FBProductCategory { get; set; }

        [JsonProperty("gender")]
        public ProductItemGender Gender { get; set; }

        [JsonProperty("gtin")]
        public string GTIN { get; set; }

        [JsonProperty("image_cdn_urls")]
        public Dictionary<string, string> ImageCDNURLs { get; set; } = new Dictionary<string, string>();

        [JsonProperty("image_fetch_status")]
        public MediaFetchStatus ImageFetchStatus { get; set; }

        [JsonProperty("image_url")]
        public string ImageURL { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; } = new List<string>();

        [JsonProperty("importer_address")]
        public ProductItemImporterAddress ImporterAddress { get; set; }

        [JsonProperty("importer_name")]
        public string ImporterName { get; set; }

        [JsonProperty("invalidation_errors")]
        public List<ProductItemInvalidationError> InvalidationErrors { get; set; } = new List<ProductItemInvalidationError>();

        [JsonProperty("inventory")]
        public int Inventory { get; set; }

        [JsonProperty("manufacturer_info")]
        public string ManufacturerInfo { get; set; }

        [JsonProperty("manufacturer_part_number")]
        public string ManufacturerPartNumber { get; set; }

        [JsonProperty("marked_for_product_launch")]
        public string MarkedForProductLaunch { get; set; }

        [JsonProperty("material")]
        public string Material { get; set; }

        [JsonProperty("mobile_link")]
        public string MobileLink { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ordering_index")]
        public int OrderingIndex { get; set; }

        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }

        [JsonProperty("parent_product_id")]
        public long ParentProductId { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        [JsonProperty("post_conversion_signal_based_enforcement_appeal_eligibility")]
        public bool PostConversionSignalBasedEnforcementAppealEligibility { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("product_catalog")]
        public ProductCatalog ProductCatalog { get; set; }

        [JsonProperty("product_feed")]
        public ProductFeed ProductFeed { get; set; }

        [JsonProperty("product_group")]
        public ProductGroup ProductGroup { get; set; }

        [JsonProperty("product_local_info")]
        public ProductItemLocalInfo ProductLocalInfo { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }

        [JsonProperty("quantity_to_sell_on_facebook")]
        public int QuantityToSellOnFacebook { get; set; }

        [JsonProperty("retailer_id")]
        public string RetailerId { get; set; }

        [JsonProperty("retailer_product_group_id")]
        public string RetailerProductGroupId { get; set; }

        [JsonProperty("review_rejection_reasons")]
        public List<string> ReviewRejectionReasons { get; set; } = new List<string>();

        [JsonProperty("review_status")]
        public ProductItemReviewStatus ReviewStatus { get; set; }

        [JsonProperty("sale_price")]
        public string SalePrice { get; set; }

        [JsonProperty("sale_price_end_date")]
        public DateTime SalePriceEndDate { get; set; }

        [JsonProperty("sale_price_start_date")]
        public DateTime SalePriceStartDate { get; set; }

        [JsonProperty("shipping_weight_unit")]
        public ShippingWeightUnit ShippingWeightUnit { get; set; }

        [JsonProperty("shipping_weight_value")]
        public double ShippingWeightValue { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("vendor_id")]
        public string VendorId { get; set; }

        [JsonProperty("video_fetch_status")]
        public MediaFetchStatus VideoFetchStatus { get; set; }

        [JsonProperty("visibility")]
        public ProductItemVisibility Visibility { get; set; }

        [JsonProperty("wa_compliance_category")]
        public string WAComplianceCategory { get; set; }
    }
}
