using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostsIndexingSamples
{
    public class HostsIndexingSamplesResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("samples")]
        public List<HostsIndexingSamplesResponseSample> Samples { get; set; } = new List<HostsIndexingSamplesResponseSample>();
    }
}
