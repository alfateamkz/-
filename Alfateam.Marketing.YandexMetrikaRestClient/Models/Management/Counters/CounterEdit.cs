using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters
{
    public class CounterEdit : CounterFull
    {
        [JsonProperty("filters_remove")]
        public List<int> FiltersRemove { get; set; } = new List<int>();

        [JsonProperty("goals_remove")]
        public List<int> GoalsRemove { get; set; } = new List<int>();

        [JsonProperty("mirrors_remove")]
        public List<int> MirrorsRemove { get; set; } = new List<int>();

        [JsonProperty("operations_remove")]
        public List<int> OperationsRemove { get; set; } = new List<int>();
    }
}
