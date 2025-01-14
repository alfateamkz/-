using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.Applications
{
    public enum ApplicationRestrictionInfoAge
    {
        [Description("13+")]
        Age13Plus = 1,
        [Description("16+")]
        Age16Plus = 2,
        [Description("17+")]
        Age17Plus = 3,
        [Description("18+")]
        Age18Plus = 4,
        [Description("19+")]
        Age19Plus = 5,
        [Description("21+")]
        Age21Plus = 6,
    }
}
