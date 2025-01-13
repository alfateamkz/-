using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdPromotedObject
    {
        [JsonProperty("application_id")]
        public long ApplicationId { get; set; }

        [JsonProperty("boosted_product_set_id")]
        public long BoostedProductSetId { get; set; }

        [JsonProperty("conversion_goal_id")]
        public long ConversionGoalId { get; set; }

        [JsonProperty("custom_conversion_id")]
        public long CustomConversionId { get; set; }

        [JsonProperty("custom_event_str")]
        public string CustomEventStr { get; set; }

        [JsonProperty("custom_event_type")]
        public CustomEventType CustomEventType { get; set; }

        [JsonProperty("event_id")]
        public long EventId { get; set; }

        [JsonProperty("lead_ads_form_event_source_type")]
        public LeadAdsFormEventSourceType LeadAdsFormEventSourceType { get; set; }

        [JsonProperty("mcme_conversion_id")]
        public long MCMEConversionId { get; set; }

        [JsonProperty("object_store_url")]
        public string ObjectStoreURL { get; set; }

        [JsonProperty("offer_id")]
        public long OfferId { get; set; }

        [JsonProperty("offline_conversion_data_set_id")]
        public long OfflineConversionDataSetId { get; set; }

        [JsonProperty("offsite_conversion_event_id")]
        public long OffsiteConversionEventId { get; set; }

        [JsonProperty("page_id")]
        public long PageId { get; set; }

        [JsonProperty("pixel_aggregation_rule")]
        public string PixelAggregationRule { get; set; }

        [JsonProperty("pixel_id")]
        public long PixelId { get; set; }

        [JsonProperty("pixel_rule")]
        public string PixelRule { get; set; }

        [JsonProperty("place_page_set_id")]
        public long PlacePageSetId { get; set; }

        [JsonProperty("product_catalog_id")]
        public long ProductCatalogId { get; set; }

        [JsonProperty("product_set_id")]
        public long ProductSetId { get; set; }

        [JsonProperty("retention_days")]
        public string RetentionDays { get; set; }

        [JsonProperty("value_semantic_type")]
        public ValueSemanticType ValueSemanticType { get; set; }

        [JsonProperty("variation")]
        public AdPromotedObjectVariation Variation { get; set; }

        [JsonProperty("whatsapp_phone_number")]
        public long WhatsAppPhoneNumber { get; set; }
    }
}
