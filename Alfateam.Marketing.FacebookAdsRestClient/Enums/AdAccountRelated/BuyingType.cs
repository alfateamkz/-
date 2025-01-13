using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum BuyingType
    {
        [Description("AUCTION")]
        Auction = 1,
        [Description("RESERVED")]
        Reserved = 2,
    }
}
