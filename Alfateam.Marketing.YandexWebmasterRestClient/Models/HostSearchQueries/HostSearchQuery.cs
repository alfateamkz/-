using Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries
{
    public class HostSearchQuery
    {
        [JsonProperty("query_id")]
        public string QueryId { get; set; }

        [JsonProperty("query_text")]
        public string QueryText { get; set; }

        [JsonProperty("indicators")]
        public Dictionary<ApiQueryIndicator, HostSearchQueryIndicatorValue> Indicators { get; set; } = new Dictionary<ApiQueryIndicator, HostSearchQueryIndicatorValue>();
    }
}
