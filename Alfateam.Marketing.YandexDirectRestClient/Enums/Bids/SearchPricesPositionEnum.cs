using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Bids
{
    public enum SearchPricesPositionEnum
    {
        [Description("FOOTERBLOCK")]
        FooterBlock = 1,
        [Description("FOOTERFIRST")]
        FooterFirst = 2,
        [Description("PREMIUMBLOCK")]
        PremiumBlock = 3,
        [Description("PREMIUMFIRST")]
        PremiumFirst = 4,
    }
}
