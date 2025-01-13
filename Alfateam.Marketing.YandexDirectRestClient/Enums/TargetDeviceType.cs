using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums
{
    public enum TargetDeviceType
    {
        [Description("DEVICE_TYPE_MOBILE")]
        DeviceTypeMobile = 1,
        [Description("DEVICE_TYPE_TABLET")]
        DeviceTypeTablet = 2,
    }
}
