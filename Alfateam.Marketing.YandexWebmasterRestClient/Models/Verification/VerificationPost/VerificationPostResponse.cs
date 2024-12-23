using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Verification.VerificationPost
{
    public class VerificationPostResponse
    {
        [JsonProperty("verification_uin")]
        public string VerificationUIN { get; set; }

        [JsonProperty("verification_state")]
        public ApiVerificationState VerificationState { get; set; }

        [JsonProperty("verification_type")]
        public ApiVerificationType VerificationType { get; set; }

        [JsonProperty("applicable_verifiers")]
        public List<ApiExplicitVerificationType> ApplicableVerifiers { get; set; } = new List<ApiExplicitVerificationType>();
    }
}
