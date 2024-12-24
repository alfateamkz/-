using Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantURLs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantURLsHistory
{
    public class HostIdImportantURLsHistoryResponse
    {
        [JsonProperty("history")]
        public List<HostIdImportantURLModel> History { get; set; } = new List<HostIdImportantURLModel>();
    }
}
