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
    public class ExtendedCredit
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("allocated_amount")]
        public CurrencyAmount AllocatedAmount { get; set; }

        [JsonProperty("balance")]
        public CurrencyAmount Balance { get; set; }

        [JsonProperty("credit_available")]
        public CurrencyAmount CreditAvailable { get; set; }

        [JsonProperty("credit_type")]
        public ExtendedCreditType CreditType { get; set; }

        [JsonProperty("is_access_revoked")]
        public bool IsAccessRevoked { get; set; }

        [JsonProperty("is_automated_experience")]
        public bool IsAutomatedExperience { get; set; }

        [JsonProperty("legal_entity_name")]
        public string LegalEntityName { get; set; }

        [JsonProperty("liable_biz_name")]
        public string LiableBizName { get; set; }

        [JsonProperty("max_balance")]
        public CurrencyAmount MaxBalance { get; set; }

        [JsonProperty("online_max_balance")]
        public CurrencyAmount OnlineMaxBalance { get; set; }

        [JsonProperty("owner_business")]
        public Business OwnerBusiness { get; set; }

        [JsonProperty("owner_business_name")]
        public string OwnerBusinessName { get; set; }

        [JsonProperty("partition_from")]
        public string PartitionFrom { get; set; }

        [JsonProperty("receiving_credit_allocation_config")]
        public ExtendedCreditAllocationConfig ReceivingCreditAllocationConfig { get; set; }

        [JsonProperty("send_bill_to_biz_name")]
        public string SendBillToBizName { get; set; }
    }
}
