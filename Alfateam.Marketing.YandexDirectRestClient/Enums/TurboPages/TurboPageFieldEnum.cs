using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.TurboPages
{
    public enum TurboPageFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("Name")]
        Name = 2,
        [Description("Href")]
        Href = 3,
        [Description("PreviewHref")]
        PreviewHref = 4,
        [Description("TurboSiteHref")]
        TurboSiteHref = 5,
        [Description("BoundWithHref")]
        BoundWithHref = 6,
    }
}
