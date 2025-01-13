using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Creatives
{
    public enum AdFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("Type")]
        Type = 2,
        [Description("Name")]
        Name = 3,
        [Description("PreviewUrl")]
        PreviewUrl = 4,
        [Description("Width")]
        Width = 5,
        [Description("Height")]
        Height = 6,
        [Description("ThumbnailUrl")]
        ThumbnailUrl = 7,
        [Description("Associated")]
        Associated = 8,
        [Description("IsAdaptive")]
        IsAdaptive = 9,
    }
}
