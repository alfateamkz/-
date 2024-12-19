using Alfateam.Marketing.AppsFlyerRestClient.Enums.Audiences.Identifiers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling.Remove
{
    public class AIHRemoveIdentifierBodyData
    {
        [JsonProperty("key_value")]
        public string KeyValue { get; set; }

        [JsonProperty("identifiers")]
        public List<AIHRemoveIdentifierBodyDataIdentifierType> Identifiers { get; set; } = new List<AIHRemoveIdentifierBodyDataIdentifierType>();
    }
}
