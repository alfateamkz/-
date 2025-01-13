using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicTextAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.Get
{
    public class WebpageGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Bid")]
        public long Bid { get; set; }

        [JsonProperty("ContextBid")]
        public long ContextBid { get; set; }

        [JsonProperty("StrategyPriority")]
        public PriorityEnum StrategyPriority { get; set; }

        [JsonProperty("State")]
        public DynamicTextAdTargetState State { get; set; }

        [JsonProperty("StatusClarification")]
        public string StatusClarification { get; set; }

        [JsonProperty("Conditions")]
        public List<WebpageCondition> Conditions { get; set; } = new List<WebpageCondition>();

        [JsonProperty("ConditionType")]
        public WebpageTypeEnum ConditionType { get; set; }
    }
}
