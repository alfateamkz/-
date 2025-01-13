using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers
{
    public enum RetargetingAdjustmentFieldEnum
    {
        [Description("RetargetingConditionId")]
        RetargetingConditionId = 1,
        [Description("BidModifier")]
        BidModifier = 2,
        [Description("Accessible")]
        Accessible = 3,
        [Description("Enabled")]
        Enabled = 4,
    }
}
