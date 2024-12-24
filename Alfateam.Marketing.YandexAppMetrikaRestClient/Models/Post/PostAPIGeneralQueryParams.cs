using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Post;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post
{
    public class PostAPIGeneralQueryParams
    {
        [JsonProperty("post_api_key")]
        public string PostAPIKey { get; set; }

        [JsonProperty("application_id")]
        public int ApplicationId { get; set; }

        [JsonProperty("profile_id")]
        public string ProfileId { get; set; }

        [JsonProperty("appmetrica_device_id")]
        public int AppmetricaDeviceId { get; set; }

        [JsonProperty("event_timestamp")]
        public int EventTimestamp { get; set; }

        [JsonProperty("ios_ifa")]
        public string iOSIFA { get; set; }

        [JsonProperty("ios_ifv")]
        public string iOSIFV { get; set; }

        [JsonProperty("google_aid")]
        public string GoogleAID { get; set; }

        [JsonProperty("windows_aid")]
        public string WindowsAID { get; set; }

        [JsonProperty("session_type")]
        public PostSessionType SessionType { get; set; }

        [JsonProperty("os_name")]
        public OS OSName { get; set; }

        [JsonProperty("os_version")]
        public string OSVersion { get; set; }

        [JsonProperty("device_manufacturer")]
        public string DeviceManufacturer { get; set; }

        [JsonProperty("device_model")]
        public string DeviceModel { get; set; }

        [JsonProperty("device_type")]
        public DeviceType DeviceType { get; set; }

        [JsonProperty("device_locale")]
        public string DeviceLocale { get; set; }

        [JsonProperty("app_version_name")]
        public string AppVersionName { get; set; }

        [JsonProperty("app_package_name")]
        public string AppPackageName { get; set; }

        [JsonProperty("connection_type")]
        public ConnectionType ConnectionType { get; set; }

        [JsonProperty("operator_name")]
        public string OperatorName { get; set; }

        [JsonProperty("mcc")]
        public string MCC { get; set; }

        [JsonProperty("mnc")]
        public string MNC { get; set; }

        [JsonProperty("device_ipv6")]
        public string DeviceIPV6 { get; set; }
    }
}
