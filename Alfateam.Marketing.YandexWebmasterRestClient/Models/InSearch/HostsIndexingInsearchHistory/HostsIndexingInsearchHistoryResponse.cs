using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsIndexingInsearchHistory
{
    public class HostsIndexingInsearchHistoryResponse
    {
        [JsonProperty("history")]
        public List<HostsIndexingInsearchHistoryResponseItem> History { get; set; } = new List<HostsIndexingInsearchHistoryResponseItem>();
    }
}
