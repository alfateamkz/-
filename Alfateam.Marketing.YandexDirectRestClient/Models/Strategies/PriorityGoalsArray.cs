using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies
{
    public class PriorityGoalsArray
    {
        [JsonProperty("Items")]
        public List<PriorityGoalsItem> Items { get; set; } = new List<PriorityGoalsItem>();
    }
}
