using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicTextAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.Get
{
    public class WebpagesSelectionCriteria : IdsCriteria
    {
        [JsonProperty("AdGroupIds")]
        public List<long> AdGroupIds { get; set; } = new List<long>();

        [JsonProperty("CampaignIds")]
        public List<long> CampaignIds { get; set; } = new List<long>();

        [JsonProperty("States")]
        public List<DynamicTextAdTargetState> States { get; set; } = Enum.GetValues<DynamicTextAdTargetState>().ToList();
    }
}
