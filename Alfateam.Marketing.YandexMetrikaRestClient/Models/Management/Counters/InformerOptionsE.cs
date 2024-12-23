using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters.InformerOptionsE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters
{
    public class InformerOptionsE
    {
        [JsonProperty("color_arrow")]
        public InformerOptionsEColorArrow ColorArrow { get; set; }

        [JsonProperty("color_end")]
        public string ColorEnd { get; set; }

        [JsonProperty("color_start")]
        public string ColorStart { get; set; }

        [JsonProperty("color_text")]
        public InformerOptionsEColorText ColorText { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("indicator")]
        public InformerOptionsEIndicator Indicator { get; set; }

        [JsonProperty("size")]
        public InformerOptionsESize Size { get; set; }

        [JsonProperty("type")]
        public InformerOptionsEType Type { get; set; }
    }
}
