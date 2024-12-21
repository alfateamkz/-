using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ComparisonDrilldown
{
    public class ComparisonDataAB
    {
        [JsonProperty("a")]
        public List<double> A { get; set; } = new List<double>();

        [JsonProperty("b")]
        public List<double> B { get; set; } = new List<double>();
    }
}
