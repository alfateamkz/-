using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Verification
{
    public class VerificationHostOwner
    {
        [JsonProperty("user_login")]
        public string UserLogin { get; set; }

        [JsonProperty("verification_uin")]
        public string VerificationUIN { get; set; }

        [JsonProperty("verification_type")]
        public ApiVerificationType VerificationType { get; set; }

        [JsonProperty("verification_date")]
        public DateTime VerificationDate { get; set; }
    }
}
