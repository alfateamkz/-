using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration
{
    public enum PushAPIConfigAttributingEntityType
    {
        [Description("appsflyer")]
        AppsFlyer = 1,
        [Description("skadnetwork")]
        SKAdNetwork = 2
    }
}
