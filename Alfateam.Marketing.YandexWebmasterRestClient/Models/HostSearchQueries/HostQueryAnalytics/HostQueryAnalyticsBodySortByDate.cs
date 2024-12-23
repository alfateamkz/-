using Alfateam.Marketing.YandexWebmasterRestClient.Enums;
using Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostQueryAnalytics
{
    public class HostQueryAnalyticsBodySortByDate
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("statistic_field")]
        public TextIndicator StatisticField { get; set; }

        [JsonProperty("by")]
        public OrderDirection By { get; set; }
    }
}
