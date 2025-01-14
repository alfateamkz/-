using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdRules
{
    public enum AdRuleScheduleSpecType
    {
        [Description("DAILY")]
        Daily = 1,
        [Description("HOURLY")]
        Hourly = 2,
        [Description("SEMI_HOURLY")]
        SemiHourly = 3,
    }
}
