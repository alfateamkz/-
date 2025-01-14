using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum BlendingMode
    {
        [Description("lighten")]
        Lighten = 1,
        [Description("multiply")]
        Multiply = 2,
        [Description("normal")]
        Normal = 3,
    }
}
