using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums
{
    public enum NumericOperator
    {
        [Description("GREATER_THAN")]
        GreaterThan = 1,
        [Description("LESS_THAN")]
        LessThan = 2,
        [Description("EQUAL")]
        Equal = 3,
        [Description("NOT_EQUAL")]
        NotEqual = 4,
        [Description("IN_RANGE")]
        InRange = 5,
        [Description("NOT_IN_RANGE")]
        NotInRange = 6,
        [Description("IN")]
        In = 7,
        [Description("NOT_IN")]
        NotIn = 8,
        [Description("CONTAIN")]
        Contain = 9,
        [Description("NOT_CONTAIN")]
        NotContain = 10,
        [Description("ANY")]
        Any = 11,
        [Description("ALL")]
        All = 12,
        [Description("NONE")]
        None = 13,
    }
}
