using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Analytics.Cohort
{
    public enum CohortAggregationType
    {
        [Description("cumulative")]
        Cumulative = 1,
        [Description("on_day")]
        OnDay = 2,
    }
}
