using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum ObjectType
    {
        [Description("APPLICATION")]
        Application = 1,
        [Description("DOMAIN")]
        Domain = 2,
        [Description("EVENT")]
        Event = 3,
        [Description("OFFER")]
        Offer = 4,
        [Description("PAGE")]
        Page = 5,
        [Description("PHOTO")]
        Photo = 6,
        [Description("SHARE")]
        Share = 7,
        [Description("STATUS")]
        Status = 8,
        [Description("STORE_ITEM")]
        StoreItem = 9,
        [Description("VIDEO")]
        Video = 10,
        [Description("INVALID")]
        Invalid = 11,
        [Description("PRIVACY_CHECK_FAIL")]
        PrivacyCheckFail = 12,
        [Description("POST_DELETED")]
        PostDeleted = 13,
    }
}
