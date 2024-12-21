using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration
{
    public enum PushAPIConfigMethod
    {
        [Description("GET")]
        GET = 1,
        [Description("POST")]
        POST = 2
    }
}
