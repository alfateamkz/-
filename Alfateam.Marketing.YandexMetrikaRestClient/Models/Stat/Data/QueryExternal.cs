using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Data
{
    public class QueryExternal
    {
        [JsonProperty("date1")]
        public DateOnly Date1 { get; set; }

        [JsonProperty("date2")]
        public DateOnly Date2 { get; set; }

        [JsonProperty("dimensions")]
        public List<string> Dimensions { get; set; } = new List<string>();

        [JsonProperty("filters")]
        public string Filters { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("metrics")]
        public List<string> Metrics { get; set; } = new List<string>();

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("sort")]
        public List<string> Sort { get; set; } = new List<string>();

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
