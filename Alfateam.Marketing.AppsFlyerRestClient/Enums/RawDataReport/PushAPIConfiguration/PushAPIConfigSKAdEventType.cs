using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration
{
    public enum PushAPIConfigSKAdEventType
    {
        [Description("install")]
        Install = 1,
        [Description("re-download")]
        ReDownload = 2,
        [Description("in-app-event")]
        InAppEvent = 3,
        [Description("postback")]
        Postback = 4,
        [Description("postback-copy")]
        PostbacksCopy = 5,
    }
}
