using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GoalsImpl
{
    public class CompositeGoal : GoalE
    {
        [JsonProperty("steps")]
        public List<ConditionalGoal> Steps { get; set; } = new List<ConditionalGoal>();
    }
}
