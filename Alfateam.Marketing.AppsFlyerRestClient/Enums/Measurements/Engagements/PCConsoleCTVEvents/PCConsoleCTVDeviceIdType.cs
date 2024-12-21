using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements.PCConsoleCTVEvents
{
    public enum PCConsoleCTVDeviceIdType
    {
        [Description("custom")]
        Custom = 1,
        [Description("rida")]
        Rida = 2,
        [Description("vida")]
        Vida = 3,
        [Description("tifa")]
        Tifa = 4,
        [Description("lgudid")]
        LgudId = 5,
        [Description("vidaaid")]
        VidaaId = 6,
        [Description("steamid")]
        SteamId = 7,
        [Description("epicid")]
        EpicId = 8,
        [Description("psid")]
        PsId = 9,
    }
}
