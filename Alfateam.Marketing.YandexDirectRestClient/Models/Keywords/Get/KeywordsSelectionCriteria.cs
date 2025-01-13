using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Keywords.Get
{
    public class KeywordsSelectionCriteria : IdsCriteria
    {
        [JsonProperty("AdGroupIds")]
        public List<long> AdGroupIds { get; set; } = new List<long>();

        [JsonProperty("CampaignIds")]
        public List<long> CampaignIds { get; set; } = new List<long>();

        [JsonProperty("States")]
        public List<KeywordStatusSelectionEnum> States { get; set; } = new List<KeywordStatusSelectionEnum>();

        [JsonProperty("Statuses")]
        public List<KeywordStatusEnum> Statuses { get; set; } = new List<KeywordStatusEnum>();

        [JsonProperty("ServingStatuses")]
        public List<ServingStatusEnum> ServingStatuses { get; set; } = new List<ServingStatusEnum>();

        [JsonProperty("ModifiedSince")]
        public DateTime ModifiedSince { get; set; }
    }
}
