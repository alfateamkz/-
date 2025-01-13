using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum SpecialAdCategory
    {
        [Description("HOUSING")]
        Housing = 1,
        [Description("EMPLOYMENT")]
        Employment = 2,
        [Description("CREDIT")]
        Credit = 3,
        [Description("NONE")]
        None = 4,
    }
}
