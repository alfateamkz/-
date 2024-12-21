using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PCConsoleCTVEvents.MeasureInAppEvents
{
    public class MeasureInAppEventsBody
    {
        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("ip")]
        public string IP { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        [JsonProperty("device_os_version")]
        public string DeviceOSVersion { get; set; }

        [JsonProperty("device_model")]
        public string DeviceModel { get; set; }

        [JsonProperty("device_ids")]
        public List<PCConsoleCTVEventsDeviceId> DeviceIds { get; set; } = new List<PCConsoleCTVEventsDeviceId>();

        [JsonProperty("limit_ad_tracking")]
        public bool LimitAdTracking { get; set; }

        [JsonProperty("customer_user_id")]
        public string CustomerUserId { get; set; }

        [JsonProperty("app_version")]
        public string AppVersion { get; set; }

        [JsonProperty("event_name")]
        public string EventName { get; set; }

        [JsonProperty("event_parameters")]
        public MeasureInAppEventsBodyEventParameters EventParameters { get; set; }

        [JsonProperty("event_custom_parameters")]
        public string EventCustomParametersJSON { get; set; }

        [JsonProperty("sharing_filter")]
        public List<string> SharingFilter { get; set; } = new List<string>();
    }
}
