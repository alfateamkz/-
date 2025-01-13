using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums
{
    public enum BusinessTypeEnum
    {
        [Description("RETAIL")]
        Retail = 1,
        [Description("HOTELS")]
        Hotels = 2,
        [Description("REALTY")]
        Realty = 3,
        [Description("AUTOMOBILES")]
        Automobiles = 4,
        [Description("FLIGHTS")]
        Flights = 5,
        [Description("CLOTHES")]
        Clothes = 6,


        [Description("OTHER")]
        Other = 999,
    }
}
