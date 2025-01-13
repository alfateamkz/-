using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class AdGroupGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("RegionIds")]
        public List<long> RegionIds { get; set; } = new List<long>();

        [JsonProperty("RestrictedRegionIds")]
        public RestrictedRegionIds RestrictedRegionIds { get; set; }

        [JsonProperty("NegativeKeywords")]
        public NegativeKeywords NegativeKeywords { get; set; }

        [JsonProperty("NegativeKeywordSharedSetIds")]
        public NegativeKeywordSharedSetIds NegativeKeywordSharedSetIds { get; set; }

        [JsonProperty("TrackingParams")]
        public string TrackingParams { get; set; }

        [JsonProperty("Status")]
        public AdGroupStatusEnum Status { get; set; }

        [JsonProperty("ServingStatus")]
        public ServingStatusEnum ServingStatus { get; set; }

        [JsonProperty("Type")]
        public AdGroupTypesEnum Type { get; set; }

        [JsonProperty("Subtype")]
        public AdGroupSubtypeEnum Subtype { get; set; }

        [JsonProperty("MobileAppAdGroup")]
        public MobileAppAdGroupGet MobileAppAdGroup { get; set; }

        [JsonProperty("DynamicTextAdGroup")]
        public List<DynamicTextAdGroupGet> DynamicTextAdGroup { get; set; } = new List<DynamicTextAdGroupGet>();

        [JsonProperty("DynamicTextFeedAdGroup")]
        public List<DynamicTextFeedAdGroupGet> DynamicTextFeedAdGroup { get; set; } = new List<DynamicTextFeedAdGroupGet>();

        [JsonProperty("SmartAdGroup")]
        public SmartAdGroupGet SmartAdGroup { get; set; }

        [JsonProperty("TextAdGroupFeedParams")]
        public TextAdGroupFeedParamsGet TextAdGroupFeedParams { get; set; }

        [JsonProperty("UnifiedAdGroup")]
        public UnifiedAdGroupGet UnifiedAdGroup { get; set; }
    }
}
