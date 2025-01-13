using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Add
{
    public class MobileAppAdGroupAdd
    {
        [JsonProperty("StoreUrl")]
        public string StoreUrl { get; set; }

        [JsonProperty("TargetDeviceType")]
        public List<TargetDeviceType> TargetDeviceType { get; set; } = new List<TargetDeviceType>();

        [JsonProperty("TargetCarrier")]
        public TargetCarrier TargetCarrier { get; set; }

        [JsonProperty("TargetOperatingSystemVersion")]
        public string TargetOperatingSystemVersion { get; set; }
    }
}
