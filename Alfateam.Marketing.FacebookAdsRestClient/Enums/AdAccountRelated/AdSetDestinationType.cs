using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum AdSetDestinationType
    {
        [Description("WEBSITE")]
        Website = 1,
        [Description("APP")]
        App = 2,
        [Description("MESSENGER")]
        Messenger = 3,
        [Description("INSTAGRAM_DIRECT")]
        InstagramDirect = 4,
        [Description("ON_AD")]
        OnAd = 5,
        [Description("ON_POST")]
        OnPost = 6,
        [Description("ON_VIDEO")]
        OnVideo = 7,
        [Description("ON_PAGE")]
        OnPage = 8,
        [Description("ON_EVENT")]
        OnEvent = 9,
    }
}
