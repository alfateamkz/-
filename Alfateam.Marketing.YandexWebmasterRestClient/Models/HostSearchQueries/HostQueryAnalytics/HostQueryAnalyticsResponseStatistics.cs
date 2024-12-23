using Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostQueryAnalytics
{
    public class HostQueryAnalyticsResponseStatistics
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("field")]
        public ApiStatisticField Field { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}
