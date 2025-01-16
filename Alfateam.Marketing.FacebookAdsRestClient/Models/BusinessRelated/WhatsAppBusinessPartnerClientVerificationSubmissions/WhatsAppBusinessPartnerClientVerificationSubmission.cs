using Alfateam.Marketing.FacebookAdsRestClient.Enums.BusinessRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.BusinessRelated.WhatsAppBusinessPartnerClientVerificationSubmissions
{
    public class WhatsAppBusinessPartnerClientVerificationSubmission
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("client_business_id")]
        public long ClientBusinessId { get; set; }

        [JsonProperty("rejection_reasons")]
        public List<WhatsAppBusinessPartnerClientVerificationRejectedReason> RejectionReasons { get; set; } = new List<WhatsAppBusinessPartnerClientVerificationRejectedReason>();

        [JsonProperty("submitted_info")]
        public WhatsAppBusinessPartnerClientVerificationSubmissionWhatsAppBusinessPartnerClientSubmissionStructuredData SubmittedInfo { get; set; }

        [JsonProperty("submitted_time")]
        public DateTime SubmittedTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime UpdateTime { get; set; }

        [JsonProperty("verification_status")]
        public WhatsAppBusinessPartnerClientVerificationSubmissionStatus VerificationStatus { get; set; }
    }
}
