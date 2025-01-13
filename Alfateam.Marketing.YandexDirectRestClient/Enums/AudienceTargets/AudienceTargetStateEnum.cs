using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AudienceTargets
{
    public enum AudienceTargetStateEnum
    {
        [Description("ON")]
        On = 1,
        [Description("SUSPENDED")]
        Suspended = 2,


        [Description("UNKNOWN")]
        Unknown = 999,
    }
}
