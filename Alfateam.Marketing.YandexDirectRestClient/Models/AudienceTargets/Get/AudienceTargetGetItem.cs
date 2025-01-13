using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AudienceTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AudienceTargets.Get
{
    public class AudienceTargetGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("RetargetingListId")]
        public long RetargetingListId { get; set; }

        [JsonProperty("InterestId")]
        public long InterestId { get; set; }

        [JsonProperty("State")]
        public AudienceTargetStateEnum State { get; set; }

        [JsonProperty("ContextBid")]
        public long ContextBid { get; set; }

        [JsonProperty("StrategyPriority")]
        public PriorityEnum StrategyPriority { get; set; }
    }
}
