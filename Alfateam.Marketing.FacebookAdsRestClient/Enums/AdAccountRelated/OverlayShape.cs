using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum OverlayShape
    {
        [Description("circle")]
        Circle = 1,
        [Description("none")]
        None = 2,
        [Description("pill")]
        Pill = 3,
        [Description("rectangle")]
        Rectangle = 4,
        [Description("triangle")]
        Triangle = 5,
    }
}
