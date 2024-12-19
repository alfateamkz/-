using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling.Remove
{
    public class AIHRemoveIdentifierBody
    {
        [JsonProperty("key_type")]
        public string KeyType { get; set; }

        [JsonProperty("action")]
        public string Action => "remove";

        [JsonProperty("data")]
        public List<AIHRemoveIdentifierBodyData> Data { get; set; } = new List<AIHRemoveIdentifierBodyData>();
    }
}
