using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum AdCampaignLearningStageInfoStatus
    {
        [Description("LEARNING")]
        Learning = 1,
        [Description("SUCCESS")]
        Success = 2,
        [Description("FAIL")]
        Fail = 3,
    }
}
