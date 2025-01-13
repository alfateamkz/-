using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Add
{
    public class AdGroupAddItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("RegionIds")]
        public List<long> RegionIds { get; set; } = new List<long>();

        [JsonProperty("NegativeKeywords")]
        public NegativeKeywords NegativeKeywords { get; set; }

        [JsonProperty("NegativeKeywordSharedSetIds")]
        public NegativeKeywordSharedSetIds NegativeKeywordSharedSetIds { get; set; }

        [JsonProperty("TrackingParams")]
        public string TrackingParams { get; set; }

        [JsonProperty("MobileAppAdGroup")]
        public MobileAppAdGroupAdd MobileAppAdGroup { get; set; }

        [JsonProperty("DynamicTextAdGroup")]
        public List<DynamicTextAdGroupAdd> DynamicTextAdGroup { get; set; } = new List<DynamicTextAdGroupAdd>();

        [JsonProperty("DynamicTextFeedAdGroup")]
        public List<DynamicTextFeedAdGroupAdd> DynamicTextFeedAdGroup { get; set; } = new List<DynamicTextFeedAdGroupAdd>();

        [JsonProperty("CpmBannerKeywordsAdGroup")]
        public CpmBannerKeywordsAdGroupAdd CpmBannerKeywordsAdGroup { get; set; }

        [JsonProperty("CpmBannerUserProfileAdGroup")]
        public CpmBannerUserProfileAdGroupAdd CpmBannerUserProfileAdGroup { get; set; }

        [JsonProperty("CpmVideoAdGroup")]
        public CpmVideoAdGroupAdd CpmVideoAdGroup { get; set; }

        [JsonProperty("SmartAdGroup")]
        public SmartAdGroupAdd SmartAdGroup { get; set; }

        [JsonProperty("UnifiedAdGroup")]
        public UnifiedAdGroupAdd UnifiedAdGroup { get; set; }

        [JsonProperty("TextAdGroupFeedParams")]
        public TextAdGroupFeedParamsAdd TextAdGroupFeedParams { get; set; }
    }
}
