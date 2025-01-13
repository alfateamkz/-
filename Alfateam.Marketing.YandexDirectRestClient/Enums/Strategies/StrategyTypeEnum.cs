using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    public enum StrategyTypeEnum
    {
        [Description("AVERAGE_CPC")]
        AverageCPC = 1,
        [Description("AVERAGE_CPA")]
        AverageCPA = 2,
        [Description("PAY_FOR_CONVERSION")]
        PayForConversion = 3,
        [Description("WB_MAXIMUM_CONVERSION_RATE")]
        WBMaximumConversionRate = 4,
        [Description("WB_MAXIMUM_CLICKS")]
        WBMaximumClicks = 5,
        [Description("AVERAGE_CRR")]
        AverageCRR = 6,
        [Description("PAY_FOR_CONVERSION_CRR")]
        PayForConversionCRR = 7,
        [Description("AVERAGE_CPC_PER_CAMPAIGN")]
        AverageCPCPerCampaign = 8,
        [Description("AVERAGE_CPC_PER_FILTER")]
        AverageCPCPerFilter = 9,
        [Description("AVERAGE_CPA_PER_CAMPAIGN")]
        AverageCPAPerCampaign = 10,
        [Description("AVERAGE_CPA_PER_FILTER")]
        AverageCPAPerFilter = 11,
        [Description("PAY_FOR_CONVERSION_PER_CAMPAIGN")]
        PayForConversionPerCampaign = 12,
        [Description("PAY_FOR_CONVERSION_PER_FILTER")]
        PayForConversionPerFilter = 13,
        [Description("UNKNOWN")]
        Unknown = 14,
    }
}
