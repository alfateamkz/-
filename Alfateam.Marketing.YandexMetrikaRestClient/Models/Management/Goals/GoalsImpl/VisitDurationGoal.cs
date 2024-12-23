using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Goals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GoalsImpl
{
    public class VisitDurationGoal : GoalE
    {
        [JsonProperty("duration")]
        public int Duration { get; set; }
    }
}
