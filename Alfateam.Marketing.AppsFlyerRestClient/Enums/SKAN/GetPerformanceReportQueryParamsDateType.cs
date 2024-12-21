using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.SKAN
{
    public enum GetPerformanceReportQueryParamsDateType
    {
        [Description("install")]
        Install = 1,
        [Description("arrival")]
        Arrival = 2,
    }
}
