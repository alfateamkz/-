using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Alfateam.Marketing.YandexDirectRestClient.Models.AdExtensions.Get;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class AdGroupsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public AdGroupsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<AdGroupFieldEnum> FieldNames { get; set; } = new List<AdGroupFieldEnum>()
        {
            AdGroupFieldEnum.Type,
            AdGroupFieldEnum.CampaignId,
        };

        [JsonProperty("MobileAppAdGroupFieldNames")]
        public List<MobileAppAdGroupFieldEnum> MobileAppAdGroupFieldNames { get; set; } = new List<MobileAppAdGroupFieldEnum>();

        [JsonProperty("DynamicTextAdGroupFieldNames")]
        public List<DynamicTextAdGroupFieldEnum> DynamicTextAdGroupFieldNames { get; set; } = new List<DynamicTextAdGroupFieldEnum>();

        [JsonProperty("DynamicTextFeedAdGroupFieldNames")]
        public List<DynamicTextFeedAdGroupFieldEnum> DynamicTextFeedAdGroupFieldNames { get; set; } = new List<DynamicTextFeedAdGroupFieldEnum>();

        [JsonProperty("SmartAdGroupFieldNames")]
        public List<SmartAdGroupFieldEnum> SmartAdGroupFieldNames { get; set; } = new List<SmartAdGroupFieldEnum>();

        [JsonProperty("TextAdGroupFeedParamsFieldNames")]
        public List<TextAdGroupFeedParamsFieldEnum> TextAdGroupFeedParamsFieldNames { get; set; } = new List<TextAdGroupFeedParamsFieldEnum>();

        [JsonProperty("UnifiedAdGroupFieldNames")]
        public List<UnifiedAdGroupFieldEnum> UnifiedAdGroupFieldNames { get; set; } = new List<UnifiedAdGroupFieldEnum>();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
