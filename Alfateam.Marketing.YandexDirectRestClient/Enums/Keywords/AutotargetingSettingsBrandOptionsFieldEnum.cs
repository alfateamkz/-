using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords
{
    public enum AutotargetingSettingsBrandOptionsFieldEnum
    {
        [Description("WithoutBrands")]
        WithoutBrands = 1,
        [Description("WithAdvertiserBrand")]
        WithAdvertiserBrand = 2,
        [Description("WithCompetitorsBrand")]
        WithCompetitorsBrand = 3,
    }
}
