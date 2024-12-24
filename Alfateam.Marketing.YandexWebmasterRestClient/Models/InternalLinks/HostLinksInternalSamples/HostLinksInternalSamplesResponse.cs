using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.InternalLinks.HostLinksInternalSamples
{
    public class HostLinksInternalSamplesResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("links")]
        public List<HostLinksSamplesLink> Links { get; set; } = new List<HostLinksSamplesLink>();   
    } 
}
