using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Ads
{
    public enum MobileAppFeatureEnum
    {
        [Description("PRICE")]
        Price = 1,
        [Description("ICON")]
        Icon = 2,
        [Description("CUSTOMER_RATING")]
        CustomerRating = 3,
        [Description("RATINGS")]
        Ratings = 4,
    }
}
