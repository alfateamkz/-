using Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.WhatsAppBusinessAccounts
{
    public class WhatsAppBusinessAccount
    {
        [JsonProperty("analytics")]
        public WABAAnalytics Analytics { get; set; }

        [JsonProperty("business_verification_status")]
        public WhatsAppBusinessAccountVerificationStatus BusinessVerificationStatus { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("is_enabled_for_insights")]
        public bool IsEnabledForInsights { get; set; }

        [JsonProperty("marketing_messages_lite_api_status")]
        public string marketingMessagesLiteAPIStatus { get; set; }

        [JsonProperty("message_template_namespace")]
        public string MessageTemplateNamespace { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("on_behalf_of_business_info")]
        public WABAOnBehalfOfComputedInfo OnBehalfOfBusinessInfo { get; set; }

        [JsonProperty("ownership_type")]
        public string OwnershipType { get; set; }

        [JsonProperty("primary_funding_id")]
        public long PrimaryFundingId { get; set; }

        [JsonProperty("purchase_order_number")]
        public string PurchaseOrderNumber { get; set; }

        [JsonProperty("timezone_id")]
        public string TimezoneId { get; set; }
    }
}
