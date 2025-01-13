using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AudienceTargets.Add
{
    public class AudienceTargetAddItem
    {
        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("RetargetingListId")]
        public long RetargetingListId { get; set; }

        [JsonProperty("InterestId")]
        public long InterestId { get; set; }

        [JsonProperty("ContextBid")]
        public long ContextBid { get; set; }

        [JsonProperty("StrategyPriority")]
        public PriorityEnum StrategyPriority { get; set; }
    }
}
