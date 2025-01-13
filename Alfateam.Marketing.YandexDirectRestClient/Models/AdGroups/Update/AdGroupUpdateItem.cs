using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Update
{
    public class AdGroupUpdateItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("RegionIds")]
        public List<long> RegionIds { get; set; } = new List<long>();

        [JsonProperty("NegativeKeywords")]
        public NegativeKeywords NegativeKeywords { get; set; }

        [JsonProperty("NegativeKeywordSharedSetIds")]
        public NegativeKeywordSharedSetIds NegativeKeywordSharedSetIds { get; set; }

        [JsonProperty("TrackingParams")]
        public string TrackingParams { get; set; }

        [JsonProperty("MobileAppAdGroup")]
        public MobileAppAdGroupUpdate MobileAppAdGroup { get; set; }

        [JsonProperty("DynamicTextAdGroup")]
        public DynamicTextAdGroupUpdate DynamicTextAdGroup { get; set; }

        [JsonProperty("DynamicTextFeedAdGroup")]
        public DynamicTextFeedAdGroupUpdate DynamicTextFeedAdGroup { get; set; }

        [JsonProperty("SmartAdGroup")]
        public SmartAdGroupUpdate SmartAdGroup { get; set; }

        [JsonProperty("TextAdGroupFeedParams")]
        public TextAdGroupFeedParamsUpdate TextAdGroupFeedParams { get; set; }

        [JsonProperty("UnifiedAdGroup")]
        public UnifiedAdGroupUpdate UnifiedAdGroup { get; set; }
    }
}
