using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class AdGroupsSelectionCriteria
    {
        [JsonProperty("CampaignIds")]
        public List<long> CampaignIds { get; set; } = new List<long>();

        [JsonProperty("Ids")]
        public List<long> Ids { get; set; } = new List<long>();

        [JsonProperty("Types")]
        public List<AdGroupTypesEnum> Types { get; set; } = new List<AdGroupTypesEnum>();

        [JsonProperty("Statuses")]
        public List<AdGroupStatusSelectionEnum> Statuses { get; set; } = new List<AdGroupStatusSelectionEnum>();

        [JsonProperty("ServingStatuses")]
        public List<ServingStatusEnum> ServingStatuses { get; set; } = new List<ServingStatusEnum>();

        [JsonProperty("AppIconStatuses")]
        public List<AdGroupAppIconStatusSelectionEnum> AppIconStatuses { get; set; } = new List<AdGroupAppIconStatusSelectionEnum>();

        [JsonProperty("NegativeKeywordSharedSetIds")]
        public List<long> NegativeKeywordSharedSetIds { get; set; } = new List<long>();
    }
}
