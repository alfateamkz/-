using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.CustomAudiences;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdsPixels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.CustomAudiences
{
    public class CustomAudience
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("approximate_count_lower_bound")]
        public int ApproximateCountLowerBound { get; set; }

        [JsonProperty("approximate_count_upper_bound")]
        public int ApproximateCountUpperBound { get; set; }

        [JsonProperty("customer_file_source")]
        public string CustomerFileSource { get; set; }

        [JsonProperty("data_source")]
        public CustomAudienceDataSource DataSource { get; set; }

        [JsonProperty("delivery_status")]
        public Dictionary<int,string> DeliveryStatus { get; set; } = new Dictionary<int,string>();

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("external_event_source")]
        public AdsPixel ExternalEventSource { get; set; }

        [JsonProperty("is_value_based")]
        public bool IsValueBased { get; set; }

        [JsonProperty("lookalike_audience_ids")]
        public List<long> LookalikeAudienceIds { get; set; } = new List<long>();

        [JsonProperty("lookalike_spec")]
        public LookalikeSpec LookalikeSpec { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("operation_status")]
        public Dictionary<int, string> OperationStatus { get; set; } = new Dictionary<int, string>();

        [JsonProperty("opt_out_link")]
        public string OptOutLink { get; set; }

        [JsonProperty("page_deletion_marked_delete_time")]
        public int PageDeletionMarkedDeleteTime { get; set; }

        [JsonProperty("permission_for_actions")]
        public Dictionary<string, bool> PermissionForActions { get; set; } = new Dictionary<string, bool>();

        [JsonProperty("pixel_id")]
        public long PixelId { get; set; }

        [JsonProperty("retention_days")]
        public int RetentionDays { get; set; }

        [JsonProperty("rule")]
        public string Rule { get; set; }

        [JsonProperty("rule_aggregation")]
        public string RuleAggregation { get; set; }

        [JsonProperty("sharing_status")]
        public CustomAudienceSharingStatus SharingStatus { get; set; }

        [JsonProperty("subtype")]
        public CustomAudienceSubtype Subtype { get; set; }

        [JsonProperty("time_content_updated")]
        public uint TimeContentUpdated { get; set; }

        [JsonProperty("time_created")]
        public uint TimeCreated { get; set; }

        [JsonProperty("time_updated")]
        public uint TimeUpdated { get; set; }
    }
}
