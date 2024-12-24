using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostsIndexingHistory
{
    public class HostsIndexingHistoryResponseIndicatorValue
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
