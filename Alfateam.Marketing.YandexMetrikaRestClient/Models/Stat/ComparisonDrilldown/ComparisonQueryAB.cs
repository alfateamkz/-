using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ComparisonDrilldown
{
    public class ComparisonQueryAB
    {
        [JsonProperty("date1_a")]
        public DateOnly Date1_A { get; set; }
     
        [JsonProperty("date1_b")]
        public DateOnly Date1_B { get; set; }

        [JsonProperty("date2_a")]
        public DateOnly Date2_A { get; set; }
      
        [JsonProperty("date2_b")]
        public DateOnly Date2_B { get; set; }

        [JsonProperty("dimensions")]
        public List<string> Dimensions { get; set; } = new List<string>();

        [JsonProperty("filters_a")]
        public string Filters_A { get; set; }

        [JsonProperty("filters_b")]
        public string Filters_B { get; set; }

        [JsonProperty("limit")]
        public string Limit { get; set; }

        [JsonProperty("metrics")]
        public List<string> Metrics { get; set; } = new List<string>();

        [JsonProperty("offset")]
        public string Offset { get; set; }

        [JsonProperty("preset")]
        public string Preset { get; set; }

        [JsonProperty("sort")]
        public List<string> Sort { get; set; } = new List<string>();

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
