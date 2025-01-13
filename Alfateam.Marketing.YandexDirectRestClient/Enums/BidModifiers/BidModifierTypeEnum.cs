using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers
{
    public enum BidModifierTypeEnum
    {
        [Description("MOBILE_ADJUSTMENT")]
        MobileAdjustment = 1,
        [Description("TABLET_ADJUSTMENT")]
        TabletAdjustment = 2,
        [Description("DESKTOP_ADJUSTMENT")]
        DesktopAdjustment = 3,
        [Description("DESKTOP_ONLY_ADJUSTMENT")]
        DesktopOnlyAdjustment = 4,
        [Description("DEMOGRAPHICS_ADJUSTMENT")]
        DemographicsAdjustment = 5,
        [Description("RETARGETING_ADJUSTMENT")]
        RetargetingAdjustment = 6,
        [Description("REGIONAL_ADJUSTMENT")]
        RegionalAdjustment = 7,
        [Description("VIDEO_ADJUSTMENT")]
        VideoAdjustment = 8,
        [Description("SMART_AD_ADJUSTMENT")]
        SmartAdAdjustment = 9,
        [Description("SERP_LAYOUT_ADJUSTMENT")]
        SERPLayoutAdjustment = 10,
        [Description("INCOME_GRADE_ADJUSTMENT")]
        IncomeGradeAdjustment = 11,
        [Description("AD_GROUP_ADJUSTMENT")]
        AdGroupAdjustment = 12,
    }
}
