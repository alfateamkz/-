using Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated;
using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated
{
    public class WhatsAppBusinessPreVerifiedPhoneNumber
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code_verification_status")]
        public WhatsAppCodeVerificationStatus CodeVerificationStatus { get; set; }

        [JsonProperty("code_verification_time")]
        public DateTime CodeVerificationTime { get; set; }

        [JsonProperty("owner_business")]
        public Business OwnerBusiness { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("verification_expiry_time")]
        public DateTime VerificationExpiryTime { get; set; }  
    }
}
