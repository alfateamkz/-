using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Grants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GetGoals
{
    public class GetGoalsResponse
    {
        [JsonProperty("goals")]
        public List<GoalE> Goals { get; set; } = new List<GoalE>();
    }
}
