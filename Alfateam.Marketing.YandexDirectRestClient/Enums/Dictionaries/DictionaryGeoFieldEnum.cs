using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries
{
    public enum DictionaryGeoFieldEnum
    {
        [Description("GeoRegionId")]
        GeoRegionId = 1,
        [Description("GeoRegionName")]
        GeoRegionName = 2,
        [Description("ParentGeoRegionNames")]
        ParentGeoRegionNames = 3,
    }
}
