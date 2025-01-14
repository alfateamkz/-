using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdRules
{
    public enum AdRuleExecutionOptionsOperator
    {
        [Description("EQUAL")]
        Equal = 1,
        [Description("IN")]
        In = 2,
    }
}
