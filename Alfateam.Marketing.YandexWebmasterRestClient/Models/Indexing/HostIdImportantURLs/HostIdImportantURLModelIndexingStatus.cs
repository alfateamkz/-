using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantURLs
{
    public class HostIdImportantURLModelIndexingStatus
    {
        [JsonProperty("status")]
        public IndexingStatusEnum Status { get; set; }

        [JsonProperty("http_code")]
        public int HTTPCode { get; set; }

        [JsonProperty("access_date")]
        public DateTime AccessDate { get; set; }
    }
}
