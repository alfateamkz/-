using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Verification.VerificationPost
{
    public class VerificationPostQueryParams
    {
        [JsonProperty("verification_type")]
        public ApiVerificationType VerificationType { get; set; }
    }
}
