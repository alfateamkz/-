using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicFeedAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicFeedAdTargets.Get
{
    public class DynamicFeedAdTargetsSelectionCriteria : IdsCriteria
    {
        [JsonProperty("AdGroupIds")]
        public List<long> AdGroupIds { get; set; } = new List<long>();

        [JsonProperty("CampaignIds")]
        public List<long> CampaignIds { get; set; } = new List<long>();

        [JsonProperty("States")]
        public List<DynamicFeedAdTargetStateSelectionEnum> States { get; set; } = new List<DynamicFeedAdTargetStateSelectionEnum>();
    }
}
