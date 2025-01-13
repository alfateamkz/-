using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AdExtensions
{
    public enum AdExtensionState
    {
        [Description("ON")]
        On = 1,
        [Description("DELETED")]
        Deleted = 2,
        [Description("UNKNOWN")]
        Unknown = 3,
    }
}
