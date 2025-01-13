using Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Get
{
    public class BidModifiersSelectionCriteria
    {
        [JsonProperty("CampaignIds")]
        public List<long> CampaignIds { get; set; } = new List<long>();

        [JsonProperty("AdGroupIds")]
        public List<long> AdGroupIds { get; set; } = new List<long>();

        [JsonProperty("Ids")]
        public List<long> Ids { get; set; } = new List<long>();

        [JsonProperty("Types")]
        public List<BidModifierTypeEnum> Types { get; set; } = new List<BidModifierTypeEnum>();

        [JsonProperty("Levels")]
        public List<BidModifierLevelEnum> Levels { get; set; } = new List<BidModifierLevelEnum>();
    }
}
