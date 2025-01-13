using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries
{
    public enum DictionariesMethod
    {
        [Description("get")]
        Get = 1,
        [Description("getGeoRegions")]
        GetGeoRegions = 2,
    }
}
