using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdImages
{
    public enum AdImageTypeEnum
    {
        [Description("SMALL")]
        Small = 1,
        [Description("REGULAR")]
        Regular = 2,
        [Description("WIDE")]
        Wide = 3,
        [Description("FIXED_IMAGE")]
        FixedImage = 4,
        [Description("UNFIT")]
        Unfit = 5,
    }
}
