using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.SmartAdTargets
{
    public enum SmartAdTargetFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("AdGroupId")]
        AdGroupId = 2,
        [Description("CampaignId")]
        CampaignId = 3,
        [Description("Name")]
        Name = 4,
        [Description("AverageCpc")]
        AverageCpc = 5,
        [Description("AverageCpa")]
        AverageCpa = 6,
        [Description("StrategyPriority")]
        StrategyPriority = 7,
        [Description("Conditions")]
        Conditions = 8,
        [Description("ConditionType")]
        ConditionType = 9,
        [Description("State")]
        State = 10,
        [Description("Audience")]
        Audience = 11,
        [Description("AvailableItemsOnly")]
        AvailableItemsOnly = 12,
    }
}
