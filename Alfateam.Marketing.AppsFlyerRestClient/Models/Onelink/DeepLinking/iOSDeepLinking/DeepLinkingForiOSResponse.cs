using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.iOSDeepLinking
{
    public class DeepLinkingForiOSResponse
    {
        [JsonProperty("found")]
        public bool Found { get; set; }

        [JsonProperty("click_event")]
        public DeepLinkingForiOSResponseClickEvent ClickEvent { get; set; }
    }
}
