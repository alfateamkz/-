using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ByTime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ComparisonDrilldown
{
    public class ComparisonDrilldownResponse : StatGeneralResponse
    {
        [JsonProperty("data")]
        public List<ComparisonRowDrillDownAB> Data { get; set; } = new List<ComparisonRowDrillDownAB>();

        [JsonProperty("query")]
        public ComparisonQueryAB Query { get; set; }
    }
}
