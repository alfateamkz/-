using Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostQueryAnalytics
{
    public class HostQueryAnalyticsBody
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("device_type_indicator")]
        public ApiDeviceTypeIndicator DeviceTypeIndicator { get; set; }

        [JsonProperty("text_indicator")]
        public TextIndicator TextIndicator { get; set; }
        
        [JsonProperty("region_ids")]
        public List<int> RegionIds { get; set; } = new List<int>();

        [JsonProperty("filters")]
        public HostQueryAnalyticsBodyFilters Filters { get; set; }

        [JsonProperty("sort_by_date")]
        public HostQueryAnalyticsBodySortByDate SortByDate { get; set; }
    }
}
