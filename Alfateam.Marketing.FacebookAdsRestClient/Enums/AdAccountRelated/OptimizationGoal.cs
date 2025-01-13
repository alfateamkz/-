using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum OptimizationGoal
    {
        [Description("NONE")]
        None = 1,
        [Description("APP_INSTALLS")]
        AppInstalls = 2,
        [Description("AD_RECALL_LIFT")]
        AdRecallLift = 3,
        [Description("ENGAGED_USERS")]
        EngagedUsers = 4,
        [Description("EVENT_RESPONSES")]
        EventResponses = 5,
        [Description("IMPRESSIONS")]
        Impressions = 6,
        [Description("LEAD_GENERATION")]
        LeadGeneration = 7,
        [Description("QUALITY_LEAD")]
        QualityLead = 8,
        [Description("LINK_CLICKS")]
        LinkClicks = 9,
        [Description("OFFSITE_CONVERSIONS")]
        OffsiteConversions = 10,
        [Description("PAGE_LIKES")]
        PageLikes = 11,
        [Description("POST_ENGAGEMENT")]
        PostEngagements = 12,
        [Description("QUALITY_CALL")]
        QualityCall = 13,
        [Description("REACH")]
        Reach = 14,
        [Description("LANDING_PAGE_VIEWS")]
        LandingPageViews = 15,
        [Description("VISIT_INSTAGRAM_PROFILE")]
        VisitInstagramProfile = 16,
        [Description("VALUE")]
        Value = 17,
        [Description("THRUPLAY")]
        ThruPlay = 18,
        [Description("DERIVED_EVENTS")]
        DerivedEvent = 19,
        [Description("APP_INSTALLS_AND_OFFSITE_CONVERSIONS")]
        AppInstallsAndOffsiteConversions = 20,
        [Description("CONVERSATIONS")]
        Conversations = 21,
        [Description("IN_APP_VALUE")]
        InAppValue = 22,
        [Description("MESSAGING_PURCHASE_CONVERSION")]
        MessagingPurchaseConversion = 23,
        [Description("SUBSCRIBERS")]
        Subscribers = 24,
        [Description("REMINDERS_SET")]
        RemindersSet = 25,
        [Description("MEANINGFUL_CALL_ATTEMPT")]
        MeaningfulCallAttempt = 26,
        [Description("PROFILE_VISIT")]
        ProfileVisit = 27,
        [Description("MESSAGING_APPOINTMENT_CONVERSION")]
        MessagingAppointmentConversion = 28,
    }
}
