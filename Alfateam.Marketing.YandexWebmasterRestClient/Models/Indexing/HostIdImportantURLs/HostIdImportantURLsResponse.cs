using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantURLs
{
    public class HostIdImportantURLsResponse
    {
        [JsonProperty("urls")]
        public List<HostIdImportantURLModel> URLs { get; set; } = new List<HostIdImportantURLModel>();
    }
}
