using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat
{
    public class StatGeneralQueryParams
    {
        [JsonProperty("ids")]
        public List<int> Ids { get; set; } = new List<int>();

        [JsonProperty("metrics")]
        public string Metrics { get; set; }

        [JsonProperty("accuracy")]
        public string Accuracy { get; set; }

        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("date1")]
        public string Date1 { get; set; }

        [JsonProperty("date2")]
        public string Date2 { get; set; }

        [JsonProperty("dimensions")]
        public string Dimensions { get; set; }

        [JsonProperty("direct_client_logins")]
        public List<string> DirectClientLogins { get; set; } = new List<string>();

        [JsonProperty("filters")]
        public string Filters { get; set; }

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
