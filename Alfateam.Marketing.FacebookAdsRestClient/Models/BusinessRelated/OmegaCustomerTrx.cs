using Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated
{
    public class OmegaCustomerTrx
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ad_account_ids")]
        public List<long> AdAccountIds { get; set; } = new List<long>();

        [JsonProperty("advertiser_name")]
        public string AdvertiserName { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("amount_due")]
        public CurrencyAmount AmountDue { get; set; }

        [JsonProperty("billed_amount_details")]
        public BilledAmountDetails BilledAmountDetails { get; set; }

        [JsonProperty("billing_period")]
        public string BillingPeriod { get; set; }

        [JsonProperty("cdn_download_uri")]
        public string CDNDownloadURI { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("download_uri")]
        public string DownloadURI { get; set; }

        [JsonProperty("due_date")]
        public DateTime DueDate { get; set; }

        [JsonProperty("entity")]
        public OmegaCustomerTrxEntityType Entity { get; set; }

        [JsonProperty("invoice_date")]
        public DateTime InvoiceDate { get; set; }

        [JsonProperty("invoice_id")]
        public long InvoiceId { get; set; }

        [JsonProperty("invoice_type")]
        public OmegaCustomerTrxEntityType InvoiceType { get; set; }

        [JsonProperty("liability_type")]
        public LiabilityType LiabilityType { get; set; }

        [JsonProperty("payment_status")]
        public PaymentStatus PaymentStatus { get; set; }

        [JsonProperty("payment_term")]
        public PaymentTerm PaymentTerm { get; set; }

        [JsonProperty("type")]
        public InvoiceType Type { get; set; }
    }
}
