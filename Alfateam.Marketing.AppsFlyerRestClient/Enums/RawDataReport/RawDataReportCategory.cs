using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport
{
    public enum RawDataReportCategory
    {
        [Description("standard")]
        Standard = 1,
        [Description("facebook")]
        Facebook = 2,
        [Description("twitter")]
        Twitter = 3,
    }
}
