using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Add
{
    public class BidModifierAddItem
    {
        [JsonProperty("MobileAdjustment")]
        public MobileAdjustmentAdd MobileAdjustment { get; set; }

        [JsonProperty("TabletAdjustment")]
        public MobileAdjustmentAdd TabletAdjustment { get; set; }

        [JsonProperty("DesktopAdjustment")]
        public DesktopAdjustmentAdd DesktopAdjustment { get; set; }

        [JsonProperty("DesktopOnlyAdjustment")]
        public DesktopAdjustmentAdd DesktopOnlyAdjustment { get; set; }

        [JsonProperty("DemographicsAdjustments")]
        public List<DemographicsAdjustmentAdd> DemographicsAdjustments { get; set; } = new List<DemographicsAdjustmentAdd>();

        [JsonProperty("RetargetingAdjustments")]
        public List<RetargetingAdjustmentAdd> RetargetingAdjustments { get; set; } = new List<RetargetingAdjustmentAdd>();

        [JsonProperty("RegionalAdjustments")]
        public List<RegionalAdjustmentAdd> RegionalAdjustments { get; set; } = new List<RegionalAdjustmentAdd>();

        [JsonProperty("VideoAdjustment")]
        public VideoAdjustmentAdd VideoAdjustment { get; set; }

        [JsonProperty("SmartAdAdjustment")]
        public SmartAdAdjustmentAdd SmartAdAdjustment { get; set; }

        [JsonProperty("SerpLayoutAdjustments")]
        public List<SerpLayoutAdjustmentAdd> SerpLayoutAdjustments { get; set; } = new List<SerpLayoutAdjustmentAdd>();

        [JsonProperty("IncomeGradeAdjustments")]
        public List<IncomeGradeAdjustmentAdd> IncomeGradeAdjustments { get; set; } = new List<IncomeGradeAdjustmentAdd>();

        [JsonProperty("AdGroupAdjustment")]
        public AdGroupAdjustmentAdd AdGroupAdjustment { get; set; }

        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }
    }
}
