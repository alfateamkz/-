using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Pivot
{
    public class PivotQueryParams : StatGeneralQueryParams
    {
        [JsonProperty("pivot_dimensions")]
        public string PivotDimensions { get; set; }

        [JsonProperty("pivot_limit")]
        public string PivotLimit { get; set; }

        [JsonProperty("pivot_offset")]
        public string PivotOffset { get; set; }
    }
}
