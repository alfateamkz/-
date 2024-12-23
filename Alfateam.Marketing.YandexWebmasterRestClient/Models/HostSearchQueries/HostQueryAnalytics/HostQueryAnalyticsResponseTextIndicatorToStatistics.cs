using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostQueryAnalytics
{
    public class HostQueryAnalyticsResponseTextIndicatorToStatistics
    {
        [JsonProperty("text_indicator")]
        public HostQueryAnalyticsResponseTextIndicator TextIndicator { get; set; }
    }
}
