using Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Get
{
    public class BidModifiersGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public BidModifiersSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<BidModifierFieldEnum> FieldNames { get; set; } = Enum.GetValues<BidModifierFieldEnum>().ToList();

        [JsonProperty("MobileAdjustmentFieldNames")]
        public List<MobileAdjustmentFieldEnum> MobileAdjustmentFieldNames { get; set; } = Enum.GetValues<MobileAdjustmentFieldEnum>().ToList();

        [JsonProperty("TabletAdjustmentFieldNames")]
        public List<TabletAdjustmentFieldEnum> TabletAdjustmentFieldNames { get; set; } = Enum.GetValues<TabletAdjustmentFieldEnum>().ToList();

        [JsonProperty("DesktopAdjustmentFieldNames")]
        public List<DesktopAdjustmentFieldEnum> DesktopAdjustmentFieldNames { get; set; } = Enum.GetValues<DesktopAdjustmentFieldEnum>().ToList();

        [JsonProperty("DesktopOnlyAdjustmentFieldNames")]
        public List<DesktopOnlyAdjustmentFieldEnum> DesktopOnlyAdjustmentFieldNames { get; set; } = Enum.GetValues<DesktopOnlyAdjustmentFieldEnum>().ToList();

        [JsonProperty("DemographicsAdjustmentFieldNames")]
        public List<DemographicsAdjustmentFieldEnum> DemographicsAdjustmentFieldNames { get; set; } = Enum.GetValues<DemographicsAdjustmentFieldEnum>().ToList();

        [JsonProperty("RetargetingAdjustmentFieldNames")]
        public List<RetargetingAdjustmentFieldEnum> RetargetingAdjustmentFieldNames { get; set; } = Enum.GetValues<RetargetingAdjustmentFieldEnum>().ToList();

        [JsonProperty("RegionalAdjustmentFieldNames")]
        public List<RegionalAdjustmentFieldEnum> RegionalAdjustmentFieldNames { get; set; } = Enum.GetValues<RegionalAdjustmentFieldEnum>().ToList();

        [JsonProperty("VideoAdjustmentFieldNames")]
        public List<VideoAdjustmentFieldEnum> VideoAdjustmentFieldNames { get; set; } = Enum.GetValues<VideoAdjustmentFieldEnum>().ToList();

        [JsonProperty("SmartAdAdjustmentFieldNames")]
        public List<SmartAdAdjustmentFieldEnum> SmartAdAdjustmentFieldNames { get; set; } = Enum.GetValues<SmartAdAdjustmentFieldEnum>().ToList();

        [JsonProperty("SerpLayoutAdjustmentFieldNames")]
        public List<SerpLayoutAdjustmentFieldEnum> SerpLayoutAdjustmentFieldNames { get; set; } = Enum.GetValues<SerpLayoutAdjustmentFieldEnum>().ToList();

        [JsonProperty("IncomeGradeAdjustmentFieldNames")]
        public List<IncomeGradeAdjustmentFieldEnum> IncomeGradeAdjustmentFieldNames { get; set; } = Enum.GetValues<IncomeGradeAdjustmentFieldEnum>().ToList();

        [JsonProperty("AdGroupAdjustmentFieldNames")]
        public List<AdGroupAdjustmentFieldEnum> AdGroupAdjustmentFieldNames { get; set; } = Enum.GetValues<AdGroupAdjustmentFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
