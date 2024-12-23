using Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostSearchQueriesHistoryAll
{
    public class HostSearchQueriesHistoryAllResponse
    {
        [JsonProperty("indicators")]
        public Dictionary<ApiQueryIndicator, HostSearchQueryIndicatorValue> Indicators { get; set; } = new Dictionary<ApiQueryIndicator, HostSearchQueryIndicatorValue>();
    }
}
