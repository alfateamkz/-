using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums
{
    public enum ErrorPriority
    {
        [Description("HIGH")]
        High = 1,
        [Description("MEDIUM")]
        Medium = 2,
        [Description("LOW")]
        Low = 3,
    }
}
