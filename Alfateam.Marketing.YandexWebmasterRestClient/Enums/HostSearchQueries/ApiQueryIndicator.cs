using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Enums.HostSearchQueries
{
    public enum ApiQueryIndicator
    {
        [Description("TOTAL_SHOWS")]
        TotalShows = 1,
        [Description("TOTAL_CLICKS")]
        TotalClicks = 2,
        [Description("AVG_SHOW_POSITION")]
        AvgShowPosition = 3,
        [Description("AVG_CLICK_POSITION")]
        AvgClickPosition = 4
    }
}
