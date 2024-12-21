using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Orders.UploadOrdersJSON
{
    public class CdpGoalExternal
    {
        [JsonProperty("goal_action_id")]
        public string GoalActionId { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

    }
}
