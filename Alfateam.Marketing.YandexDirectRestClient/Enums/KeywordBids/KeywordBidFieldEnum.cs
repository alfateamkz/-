using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordBids
{
    public enum KeywordBidFieldEnum
    {
        [Description("KeywordId")]
        KeywordId = 1,
        [Description("AdGroupId")]
        AdGroupId = 2,
        [Description("CampaignId")]
        CampaignId = 3,
        [Description("ServingStatus")]
        ServingStatus = 4,
        [Description("StrategyPriority")]
        StrategyPriority = 5,
    }
}
