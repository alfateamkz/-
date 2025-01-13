using Alfateam.Marketing.YandexDirectRestClient.Enums.Changes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Changes.Check
{
    public class ChangesCheckParamsBody
    {
        [JsonProperty("CampaignIds")]
        public List<long> CampaignIds { get; set; } = new List<long>();

        [JsonProperty("AdGroupIds")]
        public List<long> AdGroupIds { get; set; } = new List<long>();

        [JsonProperty("AdIds")]
        public List<long> AdIds { get; set; } = new List<long>();

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("FieldNames")]
        public List<ChangesCheckFieldNamesEnum> FieldNames { get; set; } = Enum.GetValues<ChangesCheckFieldNamesEnum>().ToList();
    }
}
