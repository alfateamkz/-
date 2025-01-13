using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.General
{
    public enum OnlineEventFormat
    {
        [Description("messenger_room")]
        MessengerRoom = 1,
        [Description("third_party")]
        ThirdParty = 2,
        [Description("fb_live")]
        FBLive = 3,
        [Description("horizon_world")]
        HorizonWorld = 4,

        [Description("other")]
        Other = 998,
        [Description("none")]
        None = 999,
    }
}
