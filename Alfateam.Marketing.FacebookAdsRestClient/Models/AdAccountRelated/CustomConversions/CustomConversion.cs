using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.CustomConversions;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdsPixels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.CustomConversions
{
    public class CustomConversion
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("business")]
        public Business Business { get; set; }

        [JsonProperty("creation_time")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("custom_event_type")]
        public CustomConversionCustomEventType CustomEventType { get; set; }

        [JsonProperty("data_sources")]
        public List<ExternalEventSource> DataSources { get; set; } = new List<ExternalEventSource>();

        [JsonProperty("default_conversion_value")]
        public int DefaultConversionValue { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("event_source_type")]
        public string EventSourceType { get; set; }

        [JsonProperty("first_fired_time")]
        public DateTime FirstFiredTime { get; set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        [JsonProperty("is_unavailable")]
        public bool IsUnavailable { get; set; }

        [JsonProperty("last_fired_time")]
        public DateTime LastFiredTime { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("offline_conversion_data_set")]
        public OfflineConversionDataSet OfflineConversionDataSet { get; set; }

        [JsonProperty("pixel")]
        public AdsPixel Pixel { get; set; }

        [JsonProperty("retention_days")]
        public int RetentionDays { get; set; }

        [JsonProperty("rule")]
        public string Rule { get; set; }
    }
}
