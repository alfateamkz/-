using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.General
{
    public enum GroupPrivacy
    {
        [Description("CLOSED")]
        Closed = 1,
        [Description("OPEN")]
        Open = 2,
        [Description("SECRET")]
        Secret = 3,
    }
}
