using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum BillingEvent
    {
        [Description("APP_INSTALLS")]
        AppInstalls = 1,
        [Description("CLICKS")]
        Clicks = 2,
        [Description("IMPRESSIONS")]
        Impressions = 3,
        [Description("LINK_CLICKS")]
        LinkClicks = 4,
        [Description("NONE")]
        None = 5,
        [Description("OFFER_CLAIMS")]
        OfferClaims = 6,
        [Description("PAGE_LIKES")]
        PageLikes = 7,
        [Description("POST_ENGAGEMENT")]
        PostEngagement = 8,
        [Description("THRUPLAY")]
        ThruPlay = 9,
        [Description("PURCHASE")]
        Purchase = 10,
        [Description("LISTING_INTERACTION")]
        ListingInteraction = 11,
    }
}
