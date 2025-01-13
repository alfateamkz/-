using Alfateam.Marketing.YandexDirectRestClient.Enums.AudienceTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AudienceTargets.Get
{
    public class AudienceTargetSelectionCriteria
    {
        [JsonProperty("Ids")]
        public List<long> Ids { get; set; } = new List<long>();

        [JsonProperty("AdGroupIds")]
        public List<long> AdGroupIds { get; set; } = new List<long>();

        [JsonProperty("CampaignIds")]
        public List<long> CampaignIds { get; set; } = new List<long>();

        [JsonProperty("RetargetingListIds")]
        public List<long> RetargetingListIds { get; set; } = new List<long>();

        [JsonProperty("InterestIds")]
        public List<long> InterestIds { get; set; } = new List<long>();

        [JsonProperty("States")]
        public List<AudienceTargetStateEnum> States { get; set; } = new List<AudienceTargetStateEnum>();
    }
}
