using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum TextType
    {
        [Description("price")]
        Price = 1,
        [Description("strikethrough_price")]
        StrikethroughPrice = 2,
        [Description("percentage_off")]
        PercentageOff = 3,
        [Description("custom")]
        Custom = 4,
        [Description("from_price")]
        FromPrice = 5,
        [Description("disclaimer")]
        Disclaimer = 6,
        [Description("guest_rating")]
        GuestRating = 7,
        [Description("star_rating")]
        StarRating = 8,
        [Description("sustainable")]
        Sustainable = 9,
        [Description("automated_personalize")]
        AutomatedPersonalize = 10,
    }
}
