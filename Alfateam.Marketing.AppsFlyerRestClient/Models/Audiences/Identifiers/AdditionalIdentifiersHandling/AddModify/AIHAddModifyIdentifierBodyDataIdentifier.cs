using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling.AddModify
{
    public class AIHAddModifyIdentifierBodyDataIdentifier
    {
        [JsonProperty("hashed_emails")]
        public List<string> HashedEmails { get; set; } = new List<string>();

        [JsonProperty("phone_number_sha256")]
        public string PhoneNumberSha256 { get; set; }

        [JsonProperty("phone_number_e164_sha256")]
        public string PhoneNumberE164Sha256 { get; set; }
    }
}
