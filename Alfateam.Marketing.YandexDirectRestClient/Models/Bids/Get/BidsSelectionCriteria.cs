using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Get
{
    public class BidsSelectionCriteria
    {
        [JsonProperty("KeywordIds")]
        public List<long> KeywordIds { get; set; } = new List<long>();

        [JsonProperty("AdGroupIds")]
        public List<long> AdGroupIds { get; set; } = new List<long>();

        [JsonProperty("CampaignIds")]
        public List<long> CampaignIds { get; set; } = new List<long>();

        [JsonProperty("ServingStatuses")]
        public List<ServingStatusEnum> ServingStatuses { get; set; } = new List<ServingStatusEnum>();
    }
}
