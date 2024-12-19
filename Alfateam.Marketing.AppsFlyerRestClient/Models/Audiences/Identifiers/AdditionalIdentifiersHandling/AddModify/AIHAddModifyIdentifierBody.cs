using Alfateam.Marketing.AppsFlyerRestClient.Enums.Audiences.Identifiers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling.AddModify
{
    public class AIHAddModifyIdentifierBody
    {
        [JsonProperty("key_type")]
        public string KeyType { get; set; }

        [JsonProperty("action")]
        public AIHAddModifyIdentifierActionType Action { get; set; }

        [JsonProperty("data")]
        public List<AIHAddModifyIdentifierBodyData> Data { get; set; } = new List<AIHAddModifyIdentifierBodyData>();
    }
}
