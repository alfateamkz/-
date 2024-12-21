using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.Measurements
{
    public abstract class WSToSEventManagementSendEventBody
    {
        [JsonProperty("webDevKey")]
        public string WebDevKey { get; set; }

        [JsonProperty("eventType")]
        public string EventType => "EVENT";

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("eventValue")]
        public string EventValueJSON { get; set; }

        [JsonProperty("eventRevenueCurrency")]
        public string EventRevenueCurrency { get; set; }

        [JsonProperty("eventRevenue")]
        public double EventRevenue { get; set; }

        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        [JsonProperty("UserAgent")]
        public string UserAgent { get; set; }

        [JsonProperty("ip")]
        public string IP { get; set; }
    }
}
