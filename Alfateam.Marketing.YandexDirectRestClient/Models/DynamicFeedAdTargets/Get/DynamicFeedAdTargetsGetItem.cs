using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicFeedAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicFeedAdTargets.Get
{
    public class DynamicFeedAdTargetsGetItem
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

        [JsonProperty("State")]
        public DynamicFeedAdTargetState State { get; set; }

        [JsonProperty("Conditions")]
        public ConditionsArray Conditions { get; set; }

        [JsonProperty("ConditionType")]
        public DynamicFeedAdTargetsTypeEnum ConditionType { get; set; }

        [JsonProperty("AvailableItemsOnly")]
        public YesNoEnum AvailableItemsOnly { get; set; }
    }
}
