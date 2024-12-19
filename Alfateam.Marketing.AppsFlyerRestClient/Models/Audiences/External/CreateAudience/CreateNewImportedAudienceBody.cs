using Alfateam.Marketing.AppsFlyerRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.CreateAudience
{
    public class CreateNewImportedAudienceBody
    {
        [JsonProperty("audience_name")]
        public string AudienceName { get; set; }

        [JsonProperty("ignore_account_identifiers_policy")]
        public bool IgnoreAccountIdentifiersPolicy { get; set; }

        [JsonProperty("platform")]
        public Platform Platform { get; set; }

        [JsonProperty("connections")]
        public List<CreateNewImportedAudienceBodyConnection> Connections { get; set; } = new List<CreateNewImportedAudienceBodyConnection>();

    }
}
