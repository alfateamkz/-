using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Post
{
    public enum RevenueEventType
    {
        [Description("one_time_purchase")]
        OneTimePurchase = 1,
        [Description("trial_started")]
        TrialStarted = 2,
        [Description("intro_started")]
        IntroStarted = 3,
        [Description("promo_started")]
        PromoStarted = 4,
        [Description("subscription_converted")]
        SubscriptionConverted = 5,
        [Description("subscription_started")]
        SubscriptionStarted = 6,
        [Description("subscription_renewed")]
        SubscriptionRenewed = 7,
        [Description("cancellation")]
        Cancellation = 8,
        [Description("uncancellation")]
        Uncancellation = 9,
        [Description("expired")]
        Expired = 10,
        [Description("billing_issues")]
        BillingIssues = 11,
        [Description("refund")]
        Refund = 12,
    }
}
