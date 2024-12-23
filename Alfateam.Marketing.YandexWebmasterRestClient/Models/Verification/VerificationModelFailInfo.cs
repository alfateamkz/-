using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.Verification
{
    public class VerificationModelFailInfo
    {
        [JsonProperty("reason")]
        public ApiVerificationFailReason Reason { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
