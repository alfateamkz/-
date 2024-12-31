using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration
{
    public enum PushAPIConfigPlatform
    {
        [Description("android")]
        Android = 1,
        [Description("ios")]
        iOS = 2,
        [Description("windowsphone")]
        WindowsPhone = 3
    }
}
