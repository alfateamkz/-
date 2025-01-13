using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords
{
    public enum AutotargetingSettingsCategoriesFieldEnum
    {
        [Description("Exact")]
        Exact = 1,
        [Description("Narrow")]
        Narrow = 2,
        [Description("Alternative")]
        Alternative = 3,
        [Description("Accessory")]
        Accessory = 4,
        [Description("Broader")]
        Broader = 5,
    }
}
