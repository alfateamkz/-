using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostsIndexingHistory
{
    public class HostsIndexingHistoryResponse
    {
        [JsonProperty("indicators")]
        public Dictionary<IndexingStatusEnum, List<HostsIndexingHistoryResponseIndicatorValue>> Indicators { get; set; } = new Dictionary<IndexingStatusEnum, List<HostsIndexingHistoryResponseIndicatorValue>>();
    }
}
