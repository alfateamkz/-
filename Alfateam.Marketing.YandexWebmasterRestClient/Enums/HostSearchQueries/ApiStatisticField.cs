using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries
{
    public enum ApiStatisticField
    {
        [Description("IMPRESSIONS")]
        Impressions = 1,
        [Description("POSITION")]
        Position = 2,
        [Description("CLICKS")]
        Clicks = 3,
        [Description("CTR")]
        CTR = 4,
        [Description("DEMAND")]
        Demand = 5,
    }
}
