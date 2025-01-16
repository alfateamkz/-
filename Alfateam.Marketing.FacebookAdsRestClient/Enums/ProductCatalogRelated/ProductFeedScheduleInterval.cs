using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.ProductCatalogRelated
{
    public enum ProductFeedScheduleInterval
    {
        [Description("HOURLY")]
        Hourly = 1,
        [Description("DAILY")]
        Daily = 2,
        [Description("WEEKLY")]
        Weekly = 3,
        [Description("MONTHLY")]
        Monthly = 4,
    }
}
