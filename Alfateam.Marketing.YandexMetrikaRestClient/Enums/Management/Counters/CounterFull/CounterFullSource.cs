using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Enums.Management.Counters.CounterFull
{
    public enum CounterFullSource
    {
        [Description("turbodirect")]
        TurboDirect = 1,
        [Description("marketplace_direct")]
        MarketplaceDirect = 2,
        [Description("sprav")]
        Sprav = 3,
        [Description("partner")]
        Partner = 4,
        [Description("system")]
        System = 5,
        [Description("market")]
        Market = 6,
        [Description("eda")]
        Eda = 7,
        [Description("dzen")]
        Dzen = 8,
        [Description("geoadv")]
        GeoAdv = 9,
        [Description("games")]
        Games = 10
    }
}
