using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicFeedAdTargets
{
    public enum DynamicFeedAdTargetStateSelectionEnum
    {
        [Description("ON")]
        On = 1,
        [Description("OFF")]
        Off = 2,
        [Description("SUSPENDED")]
        Suspended = 3,
        [Description("DELETED")]
        Deleted = 4,
    }
}
