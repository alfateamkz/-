using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantURLs
{
    public class HostIdImportantURLModelSearchStatus
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("last_access")]
        public DateTime LastAccess { get; set; }

        [JsonProperty("excluded_url_status")]
        public ApiExcludedUrlStatus ExcludedURLStatus { get; set; }

        [JsonProperty("bad_http_status")]
        public int BadHTTPStatus { get; set; }

        [JsonProperty("searchable")]
        public bool Searchable { get; set; }

        [JsonProperty("target_url")]
        public string TargetURL { get; set; }
    }
}
