using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Analytics.Cohort
{
    public enum CohortGranularity
    {
        [Description("hour")]
        Hour = 1,
        [Description("day")]
        Day = 2
    }
}
