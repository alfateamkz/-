using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdImages
{
    public enum AdImageAddTypeEnum
    {
        [Description("REGULAR")]
        Regular = 1,
        [Description("WIDE")]
        Wide = 2,
        [Description("FIXED_IMAGE")]
        FixedImage = 3,
        [Description("AUTO")]
        Auto = 4,
    }
}
