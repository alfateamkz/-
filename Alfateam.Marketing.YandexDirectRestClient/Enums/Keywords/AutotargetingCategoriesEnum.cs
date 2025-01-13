using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords
{
    public enum AutotargetingCategoriesEnum
    {
        [Description("EXACT")]
        Exact = 1,
        [Description("ALTERNATIVE")]
        Alternative = 2,
        [Description("COMPETITOR")]
        Competitor = 3,
        [Description("BROADER")]
        Broader = 4,
        [Description("ACCESSORY")]
        Accessory = 5,
    }
}
