using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements.PreloadMeasurement
{
    public enum PreloadMeasurementAFCostModel
    {
        [Description("cpi")]
        CPI = 1,
        [Description("cpa")]
        CPA = 2,
        [Description("cpe")]
        CPE = 3,
        [Description("cpr")]
        CPR = 4,
        [Description("cpm")]
        CPM = 5,
        [Description("cpc")]
        CPC = 6,
    }
}
