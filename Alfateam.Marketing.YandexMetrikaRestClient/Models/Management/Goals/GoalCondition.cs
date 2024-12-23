using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Goals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals
{
    public class GoalCondition
    {
        [JsonProperty("type")]
        public GoalConditionType Type { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
