using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class MobileAppAdGroupGet
    {
        [JsonProperty("StoreUrl")]
        public string StoreUrl { get; set; }

        [JsonProperty("TargetDeviceType")]
        public TargetDeviceType TargetDeviceType { get; set; }

        [JsonProperty("TargetCarrier")]
        public TargetCarrier TargetCarrier { get; set; }

        [JsonProperty("TargetOperatingSystemVersion")]
        public string TargetOperatingSystemVersion { get; set; }

        [JsonProperty("AppIconModeration")]
        public ExtensionModeration AppIconModeration { get; set; }

        [JsonProperty("AppOperatingSystemType")]
        public AppOperatingSystemType AppOperatingSystemType { get; set; }

        [JsonProperty("AppAvailabilityStatus")]
        public AppAvailabilityStatus AppAvailabilityStatus { get; set; }
    }
}
