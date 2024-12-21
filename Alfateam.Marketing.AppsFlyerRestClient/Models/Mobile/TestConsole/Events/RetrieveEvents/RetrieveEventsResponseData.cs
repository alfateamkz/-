using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.TestConsole.Events.RetrieveEvents
{
    public class RetrieveEventsResponseData
    {
        [JsonProperty("sdk_timestamp")]
        public string SDKTimestamp { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("appsflyer_id")]
        public string AppsFlyerId { get; set; }

        [JsonProperty("sdk_version")]
        public string SDKVersion { get; set; }

        [JsonProperty("app_version")]
        public string AppVersion { get; set; }

        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("event_value")]
        public string EventValue { get; set; }

        [JsonProperty("customer_user_id")]
        public string CustomerUserId { get; set; }

        [JsonProperty("idfa")]
        public string IDFA { get; set; }

        [JsonProperty("idfv")]
        public string IDFF { get; set; }

        [JsonProperty("gaid")]
        public string GAID { get; set; }

        [JsonProperty("android_id")]
        public string AndroidId { get; set; }

        [JsonProperty("imei")]
        public string IMEI { get; set; }

        [JsonProperty("oaid")]
        public string OAID { get; set; }

        [JsonProperty("amazon_aid")]
        public string AmazonAID { get; set; }
    }
}
