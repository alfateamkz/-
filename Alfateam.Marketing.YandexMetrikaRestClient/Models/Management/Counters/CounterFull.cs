using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters.CounterFull;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Labels;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters
{
    public class CounterFull : CounterBrief
    {
        [JsonProperty("autogoals_enabled")]
        public bool AutoGoalsEnabled { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("counter_flags")]
        public CounterFlags CounterFlags { get; set; }

        [JsonProperty("delete_time")]
        public DateTime DeleteTime { get; set; }

        [JsonProperty("filter_robots")]
        public CounterFullFilterRobots FilterRobots { get; set; }

        [JsonProperty("measurement_tokens")]
        public List<string> MeasurementTokens { get; set; } = new List<string>();

        [JsonProperty("publisher_options")]
        public PublisherOptions PublisherOptions { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty("visit_threshold")]
        public int VisitThreshold { get; set; }
    }
}
