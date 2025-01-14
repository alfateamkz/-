using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated
{
    public enum AdAccountDisableReason
    {
        [Description("NONE")]
        None = 0,
        [Description("ADS_INTEGRITY_POLICY")]
        AdsIntegrityPolicy = 1,
        [Description("ADS_IP_REVIEW")]
        AdsIPReview = 2,
        [Description("RISK_PAYMENT")]
        RiskPayment = 3,
        [Description("GRAY_ACCOUNT_SHUT_DOWN")]
        GrayAccountShutDown = 4,
        [Description("ADS_AFC_REVIEW")]
        AdsAFCReview = 5,
        [Description("BUSINESS_INTEGRITY_RAR")]
        BusinessIntegrityRAR = 6,
        [Description("PERMANENT_CLOSE")]
        PermanentClose = 7,
        [Description("UNUSED_RESELLER_ACCOUNT")]
        UnusedResellerAccount = 8,
        [Description("UNUSED_ACCOUNT")]
        UnusedAccount = 9,
        [Description("UMBRELLA_AD_ACCOUNT")]
        UmbrellaAdAccount = 10,
        [Description("BUSINESS_MANAGER_INTEGRITY_POLICY")]
        BusinessManagerIntegrityPolicy = 11,
        [Description("MISREPRESENTED_AD_ACCOUNT")]
        MisrepresentedAdAccount = 12,
        [Description("AOAB_DESHARE_LEGAL_ENTITY")]
        AOADBDeshareLegalEntity = 13,
        [Description("CTX_THREAD_REVIEW")]
        CTXThreadReview = 14,
        [Description("COMPROMISED_AD_ACCOUNT")]
        CompromisedAdAccount = 15,
    }
}
