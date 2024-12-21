using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Data;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Pivot;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Drilldown
{
    public class DrilldownResponse : StatGeneralResponse
    {
        [JsonProperty("data")]
        public List<DrillDownRow> Data { get; set; } = new List<DrillDownRow>();

        [JsonProperty("max")]
        public List<double> Max { get; set; } = new List<double>();

        [JsonProperty("min")]
        public List<double> Min { get; set; } = new List<double>();

        [JsonProperty("query")]
        public QueryExternal Query { get; set; }
    }
}
