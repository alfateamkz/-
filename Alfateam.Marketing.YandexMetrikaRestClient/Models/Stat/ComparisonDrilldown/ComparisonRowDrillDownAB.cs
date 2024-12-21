using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ComparisonDrilldown
{
    public class ComparisonRowDrillDownAB
    {
        [JsonProperty("dimension")]
        public List<string> Dimension { get; set; } = new List<string>();

        [JsonProperty("expand")]
        public bool Expand { get; set; }

        [JsonProperty("metrics")]
        public ComparisonDataAB Metrics { get; set; }
    }
}
