using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdRules
{
    public enum AdRuleEvaluationSpecType
    {
        [Description("SCHEDULE")]
        Schedule = 1,
        [Description("TRIGGER")]
        Trigger = 2,
    }
}
