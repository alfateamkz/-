using Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.iOSDeepLinking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.AndroidDeepLinking
{
    public class DeepLinkingForAndroidResponse
    {
        [JsonProperty("found")]
        public bool Found { get; set; }

        [JsonProperty("click_event")]
        public DeepLinkingForAndroidResponseClickEvent ClickEvent { get; set; }
    }
}
