using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling.AddModify
{
    public class AIHAddModifyIdentifierBodyData
    {
        [JsonProperty("key_value")]
        public string KeyValue { get; set; }

        [JsonProperty("identifiers")]
        public List<AIHAddModifyIdentifierBodyDataIdentifier> Identifiers { get; set; } = new List<AIHAddModifyIdentifierBodyDataIdentifier>();
    }
}
