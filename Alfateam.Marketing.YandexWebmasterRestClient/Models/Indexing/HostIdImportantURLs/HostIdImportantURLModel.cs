using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Indexing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantURLs
{
    public class HostIdImportantURLModel
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("update_date")]
        public DateTime UpdateDate { get; set; }

        [JsonProperty("change_indicators")]
        public List<ApiImportantUrlChangeIndicator> ChangeIndicators { get; set; } = new List<ApiImportantUrlChangeIndicator>();

        [JsonProperty("indexing_status")]
        public HostIdImportantURLModelIndexingStatus IndexingStatus { get; set; }

        [JsonProperty("search_status")]
        public HostIdImportantURLModelSearchStatus SearchStatus { get; set; }
    }
}
