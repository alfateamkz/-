using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordBids
{
    public enum KeywordBidSearchFieldEnum
    {
        [Description("Bid")]
        Bid = 1,
        [Description("AutotargetingSearchBidIsAuto")]
        AutotargetingSearchBidIsAuto = 2,
        [Description("AuctionBids")]
        AuctionBids = 3,
    }
}
