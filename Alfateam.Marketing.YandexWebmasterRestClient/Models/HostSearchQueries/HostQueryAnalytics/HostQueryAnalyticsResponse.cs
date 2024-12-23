using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostQueryAnalytics
{
    public class HostQueryAnalyticsResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("text_indicator_to_statistics")]
        public List<HostQueryAnalyticsResponseTextIndicatorToStatistics> TextIndicatorToStatistics { get; set; } = new List<HostQueryAnalyticsResponseTextIndicatorToStatistics>();
    }
}
