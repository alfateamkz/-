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
    public class KeywordsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public KeywordsSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<KeywordFieldEnum> FieldNames { get; set; } = new List<KeywordFieldEnum>();

        [JsonProperty("AutotargetingSettingsCategoriesFieldNames")]
        public List<AutotargetingSettingsCategoriesFieldEnum> AutotargetingSettingsCategoriesFieldNames { get; set; } = new List<AutotargetingSettingsCategoriesFieldEnum>();

        [JsonProperty("AutotargetingSettingsBrandOptionsFieldNames")]
        public List<AutotargetingSettingsBrandOptionsFieldEnum> AutotargetingSettingsBrandOptionsFieldNames { get; set; } = new List<AutotargetingSettingsBrandOptionsFieldEnum>();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
