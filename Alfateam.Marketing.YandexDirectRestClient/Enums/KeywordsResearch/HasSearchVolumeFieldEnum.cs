using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordsResearch
{
    public enum HasSearchVolumeFieldEnum
    {
        [Description("Keyword")]
        Keyword = 1,
        [Description("RegionIds")]
        RegionIds = 2,
        [Description("AllDevices")]
        AllDevices = 3,
        [Description("MobilePhones")]
        MobilePhones = 4,
        [Description("Tablets")]
        Tablets = 5,
        [Description("Desktops")]
        Desktops = 6,
    }
}
