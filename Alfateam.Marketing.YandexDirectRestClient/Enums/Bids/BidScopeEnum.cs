using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Bids
{
    public enum BidScopeEnum
    {
        [Description("SEARCH")]
        Search = 1,
        [Description("NETWORK")]
        Network = 2,
    }
}
