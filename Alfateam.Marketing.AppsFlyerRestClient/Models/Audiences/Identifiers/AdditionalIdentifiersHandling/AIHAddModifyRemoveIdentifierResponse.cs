using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling
{
    public class AIHAddModifyRemoveIdentifierResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("received")]
        public string Received { get; set; }

        [JsonProperty("trace-id")]
        public string TraceId { get; set; }
    }
}
