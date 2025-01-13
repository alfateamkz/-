using Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers;
using Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers.Get
{
    public class BidModifierGetItem
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Level")]
        public BidModifierLevelEnum Level { get; set; }

        [JsonProperty("Type")]
        public BidModifierTypeEnum Type { get; set; }

        [JsonProperty("MobileAdjustment")]
        public MobileAdjustmentGet MobileAdjustment { get; set; }

        [JsonProperty("TabletAdjustment")]
        public MobileAdjustmentGet TabletAdjustment { get; set; }

        [JsonProperty("DesktopAdjustment")]
        public DesktopAdjustmentGet DesktopAdjustment { get; set; }

        [JsonProperty("DesktopOnlyAdjustment")]
        public DesktopAdjustmentGet DesktopOnlyAdjustment { get; set; }

        [JsonProperty("DemographicsAdjustments")]
        public List<DemographicsAdjustmentGet> DemographicsAdjustments { get; set; } = new List<DemographicsAdjustmentGet>();

        [JsonProperty("RetargetingAdjustments")]
        public List<RetargetingAdjustmentGet> RetargetingAdjustments { get; set; } = new List<RetargetingAdjustmentGet>();

        [JsonProperty("RegionalAdjustments")]
        public List<RegionalAdjustmentGet> RegionalAdjustments { get; set; } = new List<RegionalAdjustmentGet>();

        [JsonProperty("VideoAdjustment")]
        public VideoAdjustmentGet VideoAdjustment { get; set; }

        [JsonProperty("SmartAdAdjustment")]
        public SmartAdAdjustmentGet SmartAdAdjustment { get; set; }

        [JsonProperty("SerpLayoutAdjustments")]
        public List<SerpLayoutAdjustmentGet> SerpLayoutAdjustments { get; set; } = new List<SerpLayoutAdjustmentGet>();

        [JsonProperty("IncomeGradeAdjustments")]
        public List<IncomeGradeAdjustmentGet> IncomeGradeAdjustments { get; set; } = new List<IncomeGradeAdjustmentGet>();

        [JsonProperty("AdGroupAdjustment")]
        public AdGroupAdjustmentGet AdGroupAdjustment { get; set; }
    }
}
