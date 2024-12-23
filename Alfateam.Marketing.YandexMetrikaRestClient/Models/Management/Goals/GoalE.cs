using Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Goals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals
{
    public class GoalE
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public GoalsType Type { get; set; }

        [JsonProperty("default_price")]
        public double DefaultPrice { get; set; }

        [JsonProperty("goal_source")]
        public GoalsSource GoalSource { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("is_favorite")]
        public bool IsFavorite { get; set; }
    }
}
