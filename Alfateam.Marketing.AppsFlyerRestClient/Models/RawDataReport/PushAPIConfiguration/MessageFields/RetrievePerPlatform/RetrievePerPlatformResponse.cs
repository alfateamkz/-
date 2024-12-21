using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.MessageFields.RetrievePerPlatform
{
    public class RetrievePerPlatformResponse
    {
        [JsonProperty("fields")]
        public List<string> Fields { get; set; } = new List<string>();

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
