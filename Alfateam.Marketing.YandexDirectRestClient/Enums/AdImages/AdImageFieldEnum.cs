using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdImages
{
    public enum AdImageFieldEnum
    {
        [Description("AdImageHash")]
        AdImageHash = 1,
        [Description("OriginalUrl")]
        OriginalUrl = 2,
        [Description("PreviewUrl")]
        PreviewUrl = 3,
        [Description("Name")]
        Name = 4,
        [Description("Type")]
        Type = 5,
        [Description("Subtype")]
        Subtype = 6,
        [Description("Associated")]
        Associated = 7,
    }
}
