using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.Ads
{
    public enum AdgroupIssuesInfoErrorType
    {
        [Description("HARD_ERROR")]
        HardError = 1,
        [Description("SOFT_ERROR")]
        SoftError = 2,
    }
}
