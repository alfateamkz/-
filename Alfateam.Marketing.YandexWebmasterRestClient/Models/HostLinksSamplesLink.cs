using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models
{
    public class HostLinksSamplesLink
    {
        [JsonProperty("source_url")]
        public string SourceURL { get; set; }

        [JsonProperty("destination_url")]
        public string DestinationURL { get; set; }

        [JsonProperty("discovery_date")]
        public DateTime DiscoveryDate { get; set; }

        [JsonProperty("source_last_access_date")]
        public DateTime SourceLastAccessDate { get; set; }
    }
}
