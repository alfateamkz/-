using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing;
using Alfateam.Marketing.YandexWebmasterRestClient.Enums.InSearch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsSearchEventsSamples
{
    public class HostsSearchEventsSample
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("event_date")]
        public DateTime EventDate { get; set; }

        [JsonProperty("last_access")]
        public DateTime LastAccess { get; set; }

        [JsonProperty("event")]
        public ApiSearchEventEnum Event { get; set; }

        [JsonProperty("excluded_url_status")]
        public ApiExcludedUrlStatus ExcludedURLStatus { get; set; }

        [JsonProperty("bad_http_status")]
        public int BadHTTPStatus { get; set; }

        [JsonProperty("target_url")]
        public string TargetURL { get; set; }
    }
}
