using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements.PCConsoleCTVEvents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PCConsoleCTVEvents
{
    public class PCConsoleCTVEventsDeviceId
    {
        [JsonProperty("type")]
        public PCConsoleCTVDeviceIdType Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
