using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Analytics.Cohort
{
    public enum CohortKPIType
    {
        [Description("users")]
        Users = 1,
        [Description("ecpi")]
        Ecpi = 2,
        [Description("cost")]
        Cost = 3,
        [Description("event_name")]
        EventName = 4,
        [Description("revenue")]
        Revenue = 5,
        [Description("roas")]
        Roas = 6,
        [Description("roi")]
        ROI = 7,
        [Description("sessions")]
        Sessions = 8,
        [Description("uninstalls")]
        Uninstalls = 9

    }
}
