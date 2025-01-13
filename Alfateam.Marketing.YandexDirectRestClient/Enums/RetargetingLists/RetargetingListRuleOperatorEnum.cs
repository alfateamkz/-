using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.RetargetingLists
{
    public enum RetargetingListRuleOperatorEnum
    {
        [Description("ALL")]
        All = 1,
        [Description("ANY")]
        Any = 2,
        [Description("NONE")]
        None = 3,
    }
}
