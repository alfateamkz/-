using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Ads
{
    public enum MobileAppAdActionEnum
    {
        [Description("DOWNLOAD")]
        Download = 1,
        [Description("GET")]
        Get = 2,
        [Description("INSTALL")]
        Install = 3,
        [Description("MORE")]
        More = 4,
        [Description("OPEN")]
        Open = 5,
        [Description("UPDATE")]
        Update = 6,
        [Description("PLAY")]
        Play = 7,
        [Description("BUY_AUTODETECT")]
        BuyAutodetect = 8,
    }
}
