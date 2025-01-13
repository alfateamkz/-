using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Bids
{
    public enum BidFieldEnum
    {
        [Description("KeywordId")]
        KeywordId = 1,
        [Description("AuctionBids")]
        AuctionBids = 2,
        [Description("CompetitorsBids")]
        CompetitorsBids = 3,
        [Description("SearchPrices")]
        SearchPrices = 4,
        [Description("MinSearchPrice")]
        MinSearchPrice = 5,
        [Description("CurrentSearchPrice")]
        CurrentSearchPrice = 6,
        [Description("ContextCoverage")]
        ContextCoverage = 7,
    }
}
