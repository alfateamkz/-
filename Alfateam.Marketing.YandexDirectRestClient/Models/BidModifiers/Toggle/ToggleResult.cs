using Alfateam.Marketing.YandexDirectRestClient.Abstractions.Models;
using Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Toggle
{
    public class ToggleResult : AbsActionResult
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("Type")]
        public BidModifierToggleTypeEnum Type { get; set; }
    }
}
