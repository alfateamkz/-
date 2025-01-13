using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Bids
{
    public enum BidPositionEnum
    {
        [Description("PREMIUMFIRST")]
        PremiumFirst = 1,
        [Description("PREMIUMBLOCK")]
        PremiumBlock = 2,
        [Description("FOOTERFIRST")]
        FooterFirst = 3,
        [Description("FOOTERBLOCK")]
        FooterBlock = 4,
        [Description("P11")]
        P11 = 5,
        [Description("P12")]
        P12 = 6,
        [Description("P13")]
        P13 = 7,
        [Description("P14")]
        P14 = 8,
        [Description("P21")]
        P21 = 9,
        [Description("P22")]
        P22 = 10,
        [Description("P23")]
        P23 = 11,
        [Description("P24")]
        P24 = 12,
    }
}
