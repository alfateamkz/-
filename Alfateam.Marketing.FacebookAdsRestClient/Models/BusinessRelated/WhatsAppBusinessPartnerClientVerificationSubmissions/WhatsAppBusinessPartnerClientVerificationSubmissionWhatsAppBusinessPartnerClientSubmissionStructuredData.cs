using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.WhatsAppBusinessPartnerClientVerificationSubmissions
{
    public class WhatsAppBusinessPartnerClientVerificationSubmissionWhatsAppBusinessPartnerClientSubmissionStructuredData
    {
        [JsonProperty("average_monthly_revenue_spend_with_partner")]
        public WhatsAppBusinessPartnerClientVerificationSubmissionWhatsAppBusinessPartnerClientCurrencyShapeStructuredData AverageMonthlyRevenueSpendWithPartner { get; set; }

        [JsonProperty("end_business_address")]
        public WhatsAppBusinessPartnerClientVerificationSubmissionWhatsAppBusinessPartnerClientAddressStructuredData EndBusinessAddress { get; set; }

        [JsonProperty("end_business_legal_name")]
        public string EndBusinessLegalName { get; set; }

        [JsonProperty("end_business_website")]
        public string EndBusinessWebsite { get; set; }

        [JsonProperty("num_billing_cycles_with_partner")]
        public int NumBillingCyclesWithPartner { get; set; }
    }
}
