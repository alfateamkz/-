using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Applications
{
    public class ApplicationObjectStoreURLs
    {
        [JsonProperty("amazon_app_store")]
        public string AmazonAppStore { get; set; }

        [JsonProperty("fb_canvas")]
        public string FBCanvas { get; set; }

        [JsonProperty("fb_gameroom")]
        public string FBGameroom { get; set; }

        [JsonProperty("google_play")]
        public string GooglePlay { get; set; }

        [JsonProperty("instant_game")]
        public string InstantGame { get; set; }

        [JsonProperty("itunes")]
        public string iTunes { get; set; }

        [JsonProperty("itunes_ipad")]
        public string iTunesiPad { get; set; }

        [JsonProperty("windows_10_store")]
        public string Windows10Store { get; set; }
    }
}
