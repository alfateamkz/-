using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicFeedAdTargets
{
    public enum DynamicFeedAdTargetFieldEnum
    {
        [Description("AdGroupId")]
        AdGroupId = 1,
        [Description("Bid")]
        Bid = 2,
        [Description("CampaignId")]
        CampaignId = 3,
        [Description("Conditions")]
        Conditions = 4,
        [Description("ConditionType")]
        ConditionType = 5,
        [Description("ContextBid")]
        ContextBid = 6,
        [Description("Id")]
        Id = 7,
        [Description("Name")]
        Name = 8,
        [Description("State")]
        State = 9,
    }
}
