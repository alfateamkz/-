using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums
{
    public enum StringConditionOperatorEnum
    {
        [Description("CONTAINS_ANY")]
        ContainsAny = 1,
        [Description("EQUALS_ANY")]
        EqualsAny = 2,
        [Description("EXISTS")]
        Exists = 3,
        [Description("GREATER_THAN")]
        GreaterThan = 4,
        [Description("IN_RANGE")]
        InRange = 5,
        [Description("LESS_THAN")]
        LessThan = 6,
        [Description("NOT_CONTAINS_ALL")]
        NotContainsAll = 7,
    }
}
