using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum PageTemporaryStatus
    {
        [Description("differently_open")]
        DifferentlyOpen = 1,
        [Description("temporarily_closed")]
        TemporarilyClosed = 2,
        [Description("operating_as_usual")]
        OperatingAsUsual = 3,
        [Description("no_data")]
        NoData = 4,
    }
}
