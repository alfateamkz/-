using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.Applications
{
    public enum ApplicationSupportedPlatform
    {
        [Description("WEB")]
        Web = 1,
        [Description("CANVAS")]
        Canvas = 2,
        [Description("MOBILE_WEB")]
        MobileWeb = 3,
        [Description("IPHONE")]
        iPhone = 4,
        [Description("IPAD")]
        iPad = 5,
        [Description("ANDROID")]
        Android = 6,
        [Description("WINDOWS")]
        Windows = 7,
        [Description("AMAZON")]
        Amazon = 8,
        [Description("SUPPLEMENTARY_IMAGES")]
        SupplementaryImages = 9,
        [Description("GAMEROOM")]
        Gameroom = 10,
        [Description("INSTANT_GAME")]
        InstantGame = 11,
        [Description("OCULUS")]
        Oculus = 12,
        [Description("SAMSUNG")]
        Samsumg = 13,
        [Description("XIAOMI")]
        Xiaomi = 14,
    }
}
