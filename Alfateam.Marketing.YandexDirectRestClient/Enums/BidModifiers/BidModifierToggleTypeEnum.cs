using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers
{
    public enum BidModifierToggleTypeEnum
    {
        [Description("DEMOGRAPHICS_ADJUSTMENT")]
        DemographicsAdjustment = 5,
        [Description("RETARGETING_ADJUSTMENT")]
        RetargetingAdjustment = 6,
        [Description("REGIONAL_ADJUSTMENT")]
        RegionalAdjustment = 7,
        [Description("SERP_LAYOUT_ADJUSTMENT")]
        SERPLayoutAdjustment = 10,
        [Description("INCOME_GRADE_ADJUSTMENT")]
        IncomeGradeAdjustment = 11,
    }
}
