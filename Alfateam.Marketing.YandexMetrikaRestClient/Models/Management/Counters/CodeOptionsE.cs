using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters
{
    public class CodeOptionsE
    {
        [JsonProperty("alternative_cdn")]
        public bool AlternativeCDN { get; set; }

        [JsonProperty("async")]
        public bool Async { get; set; }

        [JsonProperty("clickmap")]
        public bool Clickmap { get; set; }

        [JsonProperty("ecommerce")]
        public bool ECommerce { get; set; }

        [JsonProperty("in_one_line")]
        public bool InOneLine { get; set; }

        [JsonProperty("informer")]
        public InformerOptionsE Informer { get; set; }

        [JsonProperty("track_hash")]
        public bool TrackHash { get; set; }

        [JsonProperty("visor")]
        public bool Visor { get; set; }

        [JsonProperty("xml_site")]
        public bool XMLSite { get; set; }

        [JsonProperty("ytm")]
        public bool YTM { get; set; }
    }
}
