using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Drilldown
{
    public class DrillDownRow
    {
        [JsonProperty("dimension")]
        public string Dimension { get; set; }

        [JsonProperty("expand")]
        public bool Expand { get; set; }

        [JsonProperty("metrics")]
        public List<double> Metrics { get; set; } = new List<double>();
    }
}
