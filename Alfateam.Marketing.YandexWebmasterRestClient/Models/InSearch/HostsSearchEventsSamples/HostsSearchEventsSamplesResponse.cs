using Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsIndexingInSearchSamples;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsSearchEventsSamples
{
    public class HostsSearchEventsSamplesResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("samples")]
        public List<HostsSearchEventsSample> Samples { get; set; } = new List<HostsSearchEventsSample>();
    }
}
