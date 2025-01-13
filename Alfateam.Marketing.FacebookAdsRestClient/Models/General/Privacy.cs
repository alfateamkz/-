using Alfateam.Marketing.FacebookAdsRestClient.Enums.General;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class Privacy
    {
        [JsonProperty("allow")]
        public string Allow { get; set; }

        [JsonProperty("deny")]
        public string Deny { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("friends")]
        public PrivacyFriendsEnum Friends { get; set; }

        [JsonProperty("networks")]
        public string Networks { get; set; }

        [JsonProperty("value")]
        public PrivacyValueEnum Value { get; set; }
    }
}
