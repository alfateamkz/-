using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Comparison
{
    public class ComparisonQueryParams
    {
        [JsonProperty("ids")]
        public List<int> Ids { get; set; } = new List<int>();

        [JsonProperty("metrics")]
        public string Metrics { get; set; }

        [JsonProperty("accuracy")]
        public string Accuracy { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("date1_a")]
        public DateOnly Date1_A { get; set; }

        [JsonProperty("date1_b")]
        public DateOnly Date1_B { get; set; }

        [JsonProperty("date2_a")]
        public DateOnly Date2_A { get; set; }

        [JsonProperty("date2_b")]
        public DateOnly Date2_B { get; set; }

        [JsonProperty("dimensions")]
        public string Dimensions { get; set; }

        [JsonProperty("direct_client_logins")]
        public List<string> DirectClientLogins { get; set; } = new List<string>();

        [JsonProperty("filters")]
        public string Filters { get; set; }

        [JsonProperty("filters_a")]
        public string Filters_A { get; set; }

        [JsonProperty("filters_b")]
        public string Filters_B { get; set; }

        [JsonProperty("include_undefined")]
        public bool IncludeUndefined { get; set; }

        [JsonProperty("lang")]
        public string Lang { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("preset")]
        public string Preset { get; set; }

        [JsonProperty("pretty")]
        public bool Pretty { get; set; }

        [JsonProperty("proposed_accuracy")]
        public bool ProposedAccuracy { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
