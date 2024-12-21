using Alfateam.Marketing.AppsFlyerRestClient.Enums.Mobile.TestConsole;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.TestConsole.AllowedDevices.AddDevice
{
    public class AddDeviceBody
    {
        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("device_id_type")]
        public AddDeviceBodyDeviceIdType DeviceIdType { get; set; }

        [JsonProperty("device_name")]
        public string DeviceName { get; set; }
    }
}
