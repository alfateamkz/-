using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated.ProductEventStats
{
    public enum ProductEventStatDeviceType
    {
        [Description("desktop")]
        Desktop = 1,
        [Description("mobile_android_phone")]
        MobileAndroidPhone = 2,
        [Description("mobile_android_tablet")]
        MobileAndroidTablet = 3,
        [Description("mobile_ipad")]
        MobileiPad = 4,
        [Description("mobile_iphone")]
        MobileiPhone = 5,
        [Description("mobile_ipod")]
        MobileiPod = 6,
        [Description("mobile_phone")]
        MobilePhone = 7,
        [Description("mobile_tablet")]
        MobileTablet = 8,
        [Description("mobile_windows_phone")]
        MobileWindowsPhone = 9,
        [Description("unknown")]
        Unknown = 10,
    }
}
