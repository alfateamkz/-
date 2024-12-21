using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Pivot
{
    public class PivotResponse : StatGeneralResponse
    {
        [JsonProperty("data")]
        public List<PivotRow> Data { get; set; } = new List<PivotRow>();

        [JsonProperty("query")]
        public PivotQueryExternal Query { get; set; }
    }
}
