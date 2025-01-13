using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.RetargetingLists
{
    public enum RetargetingListScopeEnum
    {
        [Description("FOR_TARGETS_AND_ADJUSTMENTS")]
        ForTargetsAndAdjustments = 1,
        [Description("FOR_ADJUSTMENTS_ONLY")]
        ForAdjustmentsOnly = 2,
        [Description("FOR_TARGETS_ONLY")]
        ForTargetsOnly = 3,
    }
}
