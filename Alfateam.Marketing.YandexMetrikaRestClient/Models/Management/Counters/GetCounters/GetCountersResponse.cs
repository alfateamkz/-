using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.GetCounters
{
    public class GetCountersResponse
    {
        [JsonProperty("counters")]
        public List<CounterBrief> Counters { get; set; } = new List<CounterBrief>();

        [JsonProperty("rows")]
        public bool Rows { get; set; }
    }
}
