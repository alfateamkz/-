using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums
{
    public enum AppOperatingSystemType
    {
        [Description("IOS")]
        iOS = 1,
        [Description("ANDROID")]
        Android = 2,
        [Description("OS_TYPE_UNKNOWN")]
        OSTypeUnknown = 3
    }
}
