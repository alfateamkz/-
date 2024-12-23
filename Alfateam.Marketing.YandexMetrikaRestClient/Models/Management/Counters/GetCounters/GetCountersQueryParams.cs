using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters;
using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters.CounterFull;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.GetCounters
{
    public class GetCountersQueryParams
    {
        [JsonProperty("callback")]
        public string Callback { get; set; }

        [JsonProperty("counter_ids")]
        public List<int> CounterIds { get; set; } = new List<int>();

        [JsonProperty("favorite")]
        public bool Favorite { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("label_id")]
        public int LabelId { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("permission")]
        public GetCountersQueryParamsPermission Permission { get; set; }

        [JsonProperty("reverse")]
        public int Reverse { get; set; }

        [JsonProperty("robots")]
        public int Robots { get; set; }

        [JsonProperty("search_string")]
        public int SearchString { get; set; }

        [JsonProperty("sort")]
        public GetCountersQueryParamsSortType Sort { get; set; }

        [JsonProperty("status")]
        public CounterFullStatus Status { get; set; }

        [JsonProperty("type")]
        public CounterFullType Type { get; set; }
    }
}
