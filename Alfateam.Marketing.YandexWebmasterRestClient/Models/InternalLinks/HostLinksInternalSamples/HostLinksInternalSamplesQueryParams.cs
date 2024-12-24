using Alfateam.Marketing.YandexWebmasterRestClient.Enums.InternalLinks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.InternalLinks.HostLinksInternalSamples
{
    public class HostLinksInternalSamplesQueryParams
    {
        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("indicator")]
        public List<ApiInternalLinksBrokenIndicator> Indicators { get; set; } = new List<ApiInternalLinksBrokenIndicator>();
    }
}
