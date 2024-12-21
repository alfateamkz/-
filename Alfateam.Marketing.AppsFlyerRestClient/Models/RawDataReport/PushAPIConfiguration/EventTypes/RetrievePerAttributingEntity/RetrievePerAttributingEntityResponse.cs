using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.EventTypes.RetrievePerAttributingEntity
{
    public class RetrievePerAttributingEntityResponse
    {
        [JsonProperty("event_types")]
        public List<string> EventTypes { get; set; } = new List<string>();

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
