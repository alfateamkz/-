using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration
{
    public enum PushAPIConfigAppsFlyerEventType
    {
        [Description("organic-install-in-app-event")]
        OrganicInstallInAppEvent = 1,
        [Description("install")]
        Install = 2,
        [Description("organic-install")]
        OrganicInstall = 3,
        [Description("re-engagement")]
        ReEngagement = 4,
        [Description("re-attribution")]
        ReAttribution = 5,
        [Description("reinstall")]
        Reinstall = 6,
        [Description("organic-reinstall")]
        OrganicReinstall = 7,
        [Description("install-in-app-event")]
        InstallInAppEvent = 8,
        [Description("re-engagement-in-app-event")]
        ReEngagementInAppEvent = 9,
        [Description("re-attribution-in-app-event")]
        ReAttributionInAppEvent = 10
    }
}
