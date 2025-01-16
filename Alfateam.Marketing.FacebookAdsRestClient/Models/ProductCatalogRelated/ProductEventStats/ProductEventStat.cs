using Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated.ProductEventStats;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.CustomConversions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.ProductCatalogRelated.ProductEventStats
{
    public class ProductEventStat
    {
        [JsonProperty("date_start")]
        public DateTime DateStart { get; set; }

        [JsonProperty("date_stop")]
        public DateTime DateStop { get; set; }

        [JsonProperty("device_type")]
        public ProductEventStatDeviceType DeviceType { get; set; }

        [JsonProperty("event")]
        public ProductEventStatEvent Event { get; set; }

        [JsonProperty("event_source")]
        public ExternalEventSource EventSource { get; set; }

        [JsonProperty("total_content_ids_matched_other_catalogs")]
        public int TotalContentIdsMatchedOtherCatalogs { get; set; }

        [JsonProperty("total_matched_content_ids")]
        public int TotalMatchedContentIds { get; set; }

        [JsonProperty("total_unmatched_content_ids")]
        public int TotalUnmatchedContentIds { get; set; }

        [JsonProperty("unique_content_ids_matched_other_catalogs")]
        public int UniqueContentIdsMatchedOtherCatalogs { get; set; }

        [JsonProperty("unique_matched_content_ids")]
        public int UniqueMatchedContentIds { get; set; }

        [JsonProperty("unique_unmatched_content_ids")]
        public int UniqueUnmatchedContentIds { get; set; }
    }
}
