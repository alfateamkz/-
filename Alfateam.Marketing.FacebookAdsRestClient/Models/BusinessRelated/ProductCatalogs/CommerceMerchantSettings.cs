using Alfateam.Marketing.FacebookAdsRestClient.Abstractions.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.ProductCatalogs
{
    public class CommerceMerchantSettings
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("checkout_message")]
        public string CheckoutMessage { get; set; }

        [JsonProperty("contact_email")]
        public string ContactEmail { get; set; }

        [JsonProperty("cta")]
        public string CTA { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("facebook_channel")]
        public CommerceFacebookChannel FacebookChannel { get; set; }

        [JsonProperty("instagram_channel")]
        public CommerceInstagramChannel InstagramChannel { get; set; }

        [JsonProperty("merchant_page")]
        public Profile MerchantPage { get; set; }

        [JsonProperty("merchant_status")]
        public string MerchantStatus { get; set; }

        [JsonProperty("onsite_commerce_merchant")]
        public CommerceMerchantSettingsOnsiteCommerceMerchant OnsiteCommerceMerchant { get; set; }

        [JsonProperty("payment_provider")]
        public string PaymentProvider { get; set; }

        [JsonProperty("review_rejection_messages")]
        public List<string> ReviewRejectionMessages { get; set; } = new List<string>();

        [JsonProperty("review_rejection_reasons")]
        public List<string> ReviewRejectionReasons { get; set; } = new List<string>();

        [JsonProperty("terms")]
        public string Terms { get; set; }
    }
}
