using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords
{
    public enum KeywordStatusSelectionEnum
    {
        [Description("OFF")]
        Off = 1,
        [Description("ON")]
        On = 2,
        [Description("SUSPENDED")]
        Suspended = 3,
    }
}
