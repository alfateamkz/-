using Alfateam.Marketing.AppsFlyerRestClient.Enums.Onelink.DeepLinking.iOS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.iOSDeepLinking
{
    public class DeepLinkingForiOSBodyIdfv
    {
        [JsonProperty("type")]
        public DeepLinkingForiOSBodyIdfvType Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
