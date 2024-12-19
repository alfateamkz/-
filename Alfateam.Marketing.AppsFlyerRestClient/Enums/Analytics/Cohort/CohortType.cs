using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Analytics.Cohort
{
    public enum CohortType
    {
        [Description("user_acquisition")]
        UserAcquisition = 1,
        [Description("retargeting")]
        Retargeting = 2,
        [Description("unified")]
        Unified = 3,
    }
}
