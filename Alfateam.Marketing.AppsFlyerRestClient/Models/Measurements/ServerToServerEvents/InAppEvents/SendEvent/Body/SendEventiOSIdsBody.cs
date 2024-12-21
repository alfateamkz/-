using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.Measurements;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.ServerToServerEvents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.ServerToServerEvents.InAppEvents.SendEvent.Body
{
    public class SendEventiOSIdsBody : SendEventBody
    {
        [JsonProperty("idfa")]
        public string IDFA { get; set; }

        [JsonProperty("idfv")]
        public string IDFV { get; set; }

        [JsonProperty("appsflyer_id")]
        public string AppsflyerId { get; set; }

        [JsonProperty("customer_user_id")]
        public string CustomerUserId { get; set; }

        [JsonProperty("att")]
        public SendEventiOSIdsBodyAttType Att { get; set; }

        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("eventValue")]
        public string EventValueJSON { get; set; }

        [JsonProperty("app_version_name")]
        public string AppVersionName { get; set; }

        [JsonProperty("app_store")]
        public string AppStore { get; set; }

        [JsonProperty("eventTime")]
        public DateTime EventTime { get; set; }

        [JsonProperty("eventCurrency")]
        public string EventCurrency { get; set; }

        [JsonProperty("bundleIdentifier")]
        public string BundleIdentifier { get; set; }

        [JsonProperty("sharing_filter")]
        public List<string> SharingFilter { get; set; } = new List<string>();

        [JsonProperty("custom_dimension")]
        public string CustomDimension { get; set; }

        [JsonProperty("app_type")]
        public SendEventiOSIdsBodyAppType? AppType { get; set; }

        [JsonProperty("custom_data")]
        public string CustomDataJSON { get; set; }

        [JsonProperty("os")]
        public string OS { get; set; }

        [JsonProperty("ua")]
        public string UA { get; set; }

        [JsonProperty("aie")]
        public bool? AIE { get; set; }

        [JsonProperty("consent_data")]
        public SendEventIdsBodyConsentData ConsentData { get; set; }
    }
}
