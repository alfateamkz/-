using Alfateam.Marketing.YandexDirectRestClient.Enums.SmartAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets.Get
{
    public class SmartAdTargetsSelectionCriteria
    {
        [JsonProperty("Ids")]
        public List<long> Ids { get; set; } = new List<long>();

        [JsonProperty("AdGroupIds")]
        public List<long> AdGroupIds { get; set; } = new List<long>();

        [JsonProperty("CampaignIds")]
        public List<long> CampaignIds { get; set; } = new List<long>();

        [JsonProperty("States")]
        public List<SmartAdTargetStateSelectionEnum> States { get; set; } = new List<SmartAdTargetStateSelectionEnum>();
    }
}
