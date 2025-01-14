using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.CustomConversions
{
    public enum CustomConversionCustomEventType
    {
        [Description("ADD_PAYMENT_INFO")]
        AddPaymentInfo = 1,
        [Description("ADD_TO_CART")]
        AddToCart = 2,
        [Description("ADD_TO_WISHLIST")]
        AddToWishlist = 3,
        [Description("COMPLETE_REGISTRATION")]
        CompleteRegistration = 4,
        [Description("CONTENT_VIEW")]
        ContentView = 5,
        [Description("INITIATED_CHECKOUT")]
        InitiatedCheckout = 6,
        [Description("LEAD")]
        Lead = 7,
        [Description("PURCHASE")]
        Purchase = 8,
        [Description("SEARCH")]
        Search = 9,
        [Description("CONTACT")]
        Contact = 10,
        [Description("CUSTOMIZE_PRODUCT")]
        CustomizeProduct = 11,
        [Description("DONATE")]
        Donate = 12,
        [Description("FIND_LOCATION")]
        FindLocation = 13,
        [Description("SCHEDULE")]
        Schedule = 14,
        [Description("START_TRIAL")]
        StartTrial = 15,
        [Description("SUBMIT_APPLICATION")]
        SubmitApplication = 16,
        [Description("SUBSCRIBE")]
        Subscribe = 17,
        [Description("LISTING_INTERACTION")]
        ListingInteraction = 18,
        [Description("FACEBOOK_SELECTED")]
        FacebookSelected = 19,
        [Description("OTHER")]
        Other = 20,
    }
}
