using Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.ExtendedCredits
{
    public class ExtendedCreditAllocationConfig
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("currency_amount")]
        public CurrencyAmount CurrencyAmount { get; set; }

        [JsonProperty("liability_type")]
        public string LiabilityType { get; set; }

        [JsonProperty("owning_business")]
        public Business OwningBusiness { get; set; }

        [JsonProperty("owning_credential")]
        public ExtendedCredit OwningCredential { get; set; }

        [JsonProperty("partition_type")]
        public string PartitionType { get; set; }

        [JsonProperty("receiving_business")]
        public Business ReceivingBusiness { get; set; }

        [JsonProperty("receiving_credential")]
        public ExtendedCredit ReceivingCredential { get; set; }

        [JsonProperty("request_status")]
        public string RequestStatus { get; set; }

        [JsonProperty("send_bill_to")]
        public ExtendedCreditSendBillToEnum SendBillTo { get; set; }
    }
}
