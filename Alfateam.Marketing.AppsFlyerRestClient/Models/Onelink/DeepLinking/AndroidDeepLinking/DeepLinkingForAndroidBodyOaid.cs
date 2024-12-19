using Alfateam.Marketing.AppsFlyerRestClient.Enums.Onelink.DeepLinking.Android;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.AndroidDeepLinking
{
    public class DeepLinkingForAndroidBodyOaid
    {
        [JsonProperty("type")]
        public DeepLinkingForAndroidBodyOaidType Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
