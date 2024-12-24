using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.ExternalLinks.HostLinksExternalSamples
{
    public class HostLinksExternalSamplesResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("links")]
        public List<HostLinksSamplesLink> Links { get; set; } = new List<HostLinksSamplesLink>();
    }
}
