using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals
{
    public class WithGoalEBody
    {
        [JsonProperty("goal")]
        public GoalE Goal { get; set; }
    }
}
