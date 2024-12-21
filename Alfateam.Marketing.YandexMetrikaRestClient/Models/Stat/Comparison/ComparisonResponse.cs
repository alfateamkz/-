using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ComparisonDrilldown;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Comparison
{
    public class ComparisonResponse : StatGeneralResponse
    {
        [JsonProperty("data")]
        public List<ComparisonRowStaticAB> Data { get; set; } = new List<ComparisonRowStaticAB>();

        [JsonProperty("query")]
        public ComparisonQueryAB Query { get; set; }

        [JsonProperty("totals")]
        public new List<ComparisonDataAB> Totals { get; set; } = new List<ComparisonDataAB>();
    }
}
