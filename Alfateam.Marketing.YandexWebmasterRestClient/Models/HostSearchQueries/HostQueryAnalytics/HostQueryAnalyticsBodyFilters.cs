using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostQueryAnalytics
{
    public class HostQueryAnalyticsBodyFilters
    {
        [JsonProperty("text_filters")]
        public HostQueryAnalyticsBodyTextFilters TextFilters { get; set; }

        [JsonProperty("statistic_filters")]
        public HostQueryAnalyticsBodyStatisticFilters StatisticFilters { get; set; }
    }
}
