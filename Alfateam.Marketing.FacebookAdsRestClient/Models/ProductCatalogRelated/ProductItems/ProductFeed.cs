using Alfateam.Marketing.FacebookAdsRestClient.Enums;
using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductItems
{
    public class ProductFeed
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("default_currency")]
        public string DefaultCurrency { get; set; }

        [JsonProperty("deletion_enabled")]
        public bool DeletionEnabled { get; set; }

        [JsonProperty("delimiter")]
        public DelimiterSymbol Delimiter { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("ingestion_source_type")]
        public IngestionSourceType IngestionSourceType { get; set; }

        [JsonProperty("item_sub_type")]
        public string ItemSubType { get; set; }

        [JsonProperty("latest_upload")]
        public ProductFeedUpload LatestUpload { get; set; }

        [JsonProperty("migrated_from_feed_id")]
        public string MigratedFromFeedId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("override_type")]
        public string OverrideType { get; set; }

        [JsonProperty("primary_feeds")]
        public List<string> PrimaryFeeds { get; set; } = new List<string>();

        [JsonProperty("product_count")]
        public int ProductCount { get; set; }

        [JsonProperty("quoted_fields_mode")]
        public ProductFeedQuotedFieldsMode QuotedFieldsMode { get; set; }

        [JsonProperty("schedule")]
        public ProductFeedSchedule Schedule { get; set; }

        [JsonProperty("update_schedule")]
        public ProductFeedSchedule UpdateSchedule { get; set; }
    }
}
