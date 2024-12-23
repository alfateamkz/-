using Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostQueryAnalytics
{
    public class HostQueryAnalyticsBodyStatisticFilters
    {
        [JsonProperty("statistic_field")]
        public TextIndicator StatisticField { get; set; }

        [JsonProperty("operation")]
        public ApiNumericOperation Operation { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("from")]
        public DateOnly From { get; set; }

        [JsonProperty("to")]
        public DateOnly To { get; set; }
    }
}
