using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum BidStrategy
    {
        [Description("LOWEST_COST_WITHOUT_CAP")]
        LowestCostWithoutCap = 1,
        [Description("LOWEST_COST_WITH_BID_CAP")]
        LowestCostWithBidCap = 2,
        [Description("COST_CAP")]
        CostCap = 3,
        [Description("LOWEST_COST_WITH_MIN_ROAS")]
        LowestCostWithMinRoas = 4,
    }
}
