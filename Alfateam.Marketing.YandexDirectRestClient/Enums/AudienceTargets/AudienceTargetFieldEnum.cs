using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.AudienceTargets
{
    public enum AudienceTargetFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("AdGroupId")]
        AdGroupId = 2,
        [Description("CampaignId")]
        CampaignId = 3,
        [Description("RetargetingListId")]
        RetargetingListId = 4,
        [Description("InterestId")]
        InterestId = 5,
        [Description("ContextBid")]
        ContextBid = 6,
        [Description("StrategyPriority")]
        StrategyPriority = 7,
        [Description("State")]
        State = 8,
    }
}
