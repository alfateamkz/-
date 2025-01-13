using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.Add
{
    public class WebpageAddItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("Conditions")]
        public List<WebpageCondition> Conditions { get; set; } = new List<WebpageCondition>();

        [JsonProperty("Bid")]
        public long Bid { get; set; }

        [JsonProperty("ContextBid")]
        public long ContextBid { get; set; }

        [JsonProperty("StrategyPriority")]
        public PriorityEnum StrategyPriority { get; set; }
    }
}
