using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM
{
    public class OrderStatus
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public OrderStatusType Type { get; set; }

        [JsonProperty("goal_action_ids")]
        public List<string> GoalActionIds { get; set; } = new List<string>();

        [JsonProperty("humanized")]
        public string Humanized { get; set; }
    }
}
