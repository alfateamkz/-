using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums
{
    public enum PriorityEnum
    {
        [Description("LOW")]
        Low = 1,
        [Description("NORMAL")]
        Normal = 2,
        [Description("HIGH")]
        High = 3,
    }
}
