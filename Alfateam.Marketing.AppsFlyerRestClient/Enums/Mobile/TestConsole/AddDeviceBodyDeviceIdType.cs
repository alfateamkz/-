using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Mobile.TestConsole
{
    public enum AddDeviceBodyDeviceIdType
    {
        [Description("IDFA")]
        IDFA = 1,
        [Description("IDFV")]
        IDFV = 2,
        [Description("AID")]
        AID = 3,
        [Description("OAID")]
        OAID = 4,
        [Description("IMEI")]
        IMEI = 5,
        [Description("ANDROID ID")]
        AndroidId = 6,
        [Description("FIRE AID")]
        FireAID = 7
    }
}
