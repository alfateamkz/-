using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies
{
    public class PriorityGoalsItem
    {
        [JsonProperty("GoalId")]
        public long GoalId { get; set; }

        [JsonProperty("Value")]
        public long Value { get; set; }

        [JsonProperty("IsMetrikaSourceOfValue")]
        public YesNoEnum IsMetrikaSourceOfValue { get; set; }
    }
}
