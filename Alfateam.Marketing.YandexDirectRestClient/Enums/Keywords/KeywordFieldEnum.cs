using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Keywords
{
    public enum KeywordFieldEnum
    {
        [Description("Id")]
        Id = 1,
        [Description("Keyword")]
        Keyword = 2,
        [Description("State")]
        State = 3,
        [Description("Status")]
        Status = 4,
        [Description("ServingStatus")]
        ServingStatus = 5,
        [Description("AdGroupId")]
        AdGroupId = 6,
        [Description("CampaignId")]
        CampaignId = 7,
        [Description("Bid")]
        Bid = 8,
        [Description("AutotargetingSearchBidIsAuto")]
        AutotargetingSearchBidIsAuto = 9,
        [Description("ContextBid")]
        ContextBid = 10,
        [Description("StrategyPriority")]
        StrategyPriority = 11,
        [Description("UserParam1")]
        UserParam1 = 12,
        [Description("UserParam2")]
        UserParam2 = 13,
        [Description("Productivity")]
        Productivity = 14,
        [Description("StatisticsSearch")]
        StatisticsSearch = 15,
        [Description("StatisticsNetwork")]
        StatisticsNetwork = 16,
        [Description("AutotargetingCategories")]
        AutotargetingCategories = 17,
    }
}
