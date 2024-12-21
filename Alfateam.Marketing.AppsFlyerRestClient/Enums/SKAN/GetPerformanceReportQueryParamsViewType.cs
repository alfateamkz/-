using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.SKAN
{
    public enum GetPerformanceReportQueryParamsViewType
    {
        [Description("acquisition")]
        Acquisition = 1,
        [Description("retargeting")]
        Retargeting = 2,
        [Description("unified")]
        Unified = 3,
    }
}
