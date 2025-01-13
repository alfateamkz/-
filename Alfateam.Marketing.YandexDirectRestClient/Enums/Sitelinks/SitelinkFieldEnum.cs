using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Sitelinks
{
    public enum SitelinkFieldEnum
    {
        [Description("Title")]
        Title = 1,
        [Description("Href")]
        Href = 2,
        [Description("Description")]
        Description = 3,
        [Description("TurboPageId")]
        TurboPageId = 4,
    }
}
