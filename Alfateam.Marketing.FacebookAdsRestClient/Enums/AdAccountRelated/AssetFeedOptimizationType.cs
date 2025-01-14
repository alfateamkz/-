using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum AssetFeedOptimizationType
    {
        [Description("ASSET_CUSTOMIZATION")]
        AssetCustomization = 1,
        [Description("LANGUAGE")]
        Language = 2,
        [Description("PLACEMENT")]
        Placement = 3,
        [Description("REGULAR")]
        Regular = 4,
        [Description("FORMAT_AUTOMATION")]
        FormatAutomation = 5,
    }
}
