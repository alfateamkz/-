using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsIndexingInSearchSamples
{
    public class HostsIndexingInSearchSample
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("last_access")]
        public DateTime LastAccess { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
