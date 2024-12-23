using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries
{
    public enum ApiDeviceTypeIndicator
    {
        [Description("ALL")]
        All = 1,
        [Description("DESKTOP")]
        Desktop = 2,
        [Description("MOBILE_AND_TABLET")]
        MobileAndTablet = 3,
        [Description("MOBILE")]
        Mobile = 4,
        [Description("TABLET")]
        Tablet = 5,
    }
}
