using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ComparisonDrilldown
{
    public class ComparisonDrilldownQueryParams : StatGeneralQueryParams
    {
        [JsonProperty("date1_a")]
        public DateOnly Date1_A { get; set; }

        [JsonProperty("date1_b")]
        public DateOnly Date1_B { get; set; }

        [JsonProperty("date2_a")]
        public DateOnly Date2_A { get; set; }

        [JsonProperty("date2_b")]
        public DateOnly Date2_B { get; set; }





        [JsonProperty("filters_a")]
        public string Filters_A { get; set; }

        [JsonProperty("filters_b")]
        public string Filters_B { get; set; }


        [JsonProperty("only_expandable_undefined")]
        public bool OnlyExpandableUndefined { get; set; }

        [JsonProperty("parent_id")]
        public List<string> ParentId { get; set; } = new List<string>();    
    }
}
