using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum CustomEventType
    {
        [Description("AD_IMPRESSION")]
        AdImpression = 1,
        [Description("RATE")]
        Rate = 2,
        [Description("TUTORIAL_COMPLETION")]
        TutorialCompletion = 3,
        [Description("CONTACT")]
        Contact = 4,
        [Description("CUSTOMIZE_PRODUCT")]
        CustomizeProduct = 5,
        [Description("DONATE")]
        Donate = 6,
        [Description("FIND_LOCATION")]
        FindLocation = 7,
        [Description("SCHEDULE")]
        Schedule = 8,
        [Description("START_TRIAL")]
        StartTrial = 9,
        [Description("SUBMIT_APPLICATION")]
        SubmitApplication = 10,
        [Description("SUBSCRIBE")]
        Subscribe = 11,
        [Description("ADD_TO_CART")]
        AddToCart = 12,
        [Description("ADD_TO_WISHLIST")]
        AddToWishlist = 13,
        [Description("INITIATED_CHECKOUT")]
        InitiatedCheckout = 14,
        [Description("ADD_PAYMENT_INFO")]
        AddPaymentInfo = 15,
        [Description("PURCHASE")]
        Purchase = 16,
        [Description("LEAD")]
        Lead = 18,
        [Description("COMPLETE_REGISTRATION")]
        CompleteRegistration = 19,
        [Description("CONTENT_VIEW")]
        ContentView = 20,
        [Description("SEARCH")]
        Search = 21,
        [Description("SERVICE_BOOKING_REQUEST")]
        ServiceBookingRequest = 22,
        [Description("MESSAGING_CONVERSATION_STARTED_7D")]
        MessagingConversationStarted7D = 23,
        [Description("LEVEL_ACHIEVED")]
        LevelAchieved = 24,
        [Description("ACHIEVEMENT_UNLOCKED")]
        AchievementUnlocked = 25,
        [Description("SPENT_CREDITS")]
        SpentCredits = 26,
        [Description("LISTING_INTERACTION")]
        ListingInteraction = 27,
        [Description("D2_RETENTION")]
        D2Retention = 28,
        [Description("D7_RETENTION")]
        D7Retention = 29,




        [Description("OTHER")]
        Other = 999,
    }
}
