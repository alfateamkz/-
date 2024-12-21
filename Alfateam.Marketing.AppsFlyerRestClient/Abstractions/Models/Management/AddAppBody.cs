using Alfateam.Marketing.AppsFlyerRestClient.Enums.Management.AppManagementAPIV2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.Management
{
    public abstract class AddAppBody
    {
        [JsonProperty("platform")]
        public AddAppBodyPlatform Platform { get; set; }

        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("status")]
        public AddAppBodyStatus Status { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("kidsPrivacy")]
        public bool KidsPrivacy { get; set; }
    }
}
