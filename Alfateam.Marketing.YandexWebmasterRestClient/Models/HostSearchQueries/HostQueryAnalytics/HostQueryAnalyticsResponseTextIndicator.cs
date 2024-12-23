using Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostQueryAnalytics
{
    public class HostQueryAnalyticsResponseTextIndicator
    {
        [JsonProperty("type")]
        public TextIndicator Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
