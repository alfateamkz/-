using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters
{
    public class CounterFlags
    {
        [JsonProperty("collect_first_party_data")]
        public bool CollectFirstPartyData { get; set; }

        [JsonProperty("direct_allow_use_goals_without_access")]
        public bool DirectAllowUseGoalsWithoutAccess { get; set; }

        [JsonProperty("measurement_enabled")]
        public bool MeasurementEnabled { get; set; }

        [JsonProperty("use_in_benchmarks")]
        public bool UseInBenchmarks { get; set; }
    }
}
