using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsIndexingInSearchSamples
{
    public class HostsIndexingInSearchSamplesResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("samples")]
        public List<HostsIndexingInSearchSample> Samples { get; set; } = new List<HostsIndexingInSearchSample>();
    }
}
