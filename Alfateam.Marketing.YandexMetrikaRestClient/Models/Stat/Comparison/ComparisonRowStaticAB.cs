using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ComparisonDrilldown;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Comparison
{
    public class ComparisonRowStaticAB
    {
        [JsonProperty("dimension")]
        public List<string> Dimension { get; set; } = new List<string>();

        [JsonProperty("metrics")]
        public ComparisonDataAB Metrics { get; set; }
    }
}
