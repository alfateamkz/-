using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeTemplateURLSpec
    {
        [JsonProperty("android")]
        public AdCreativeAndroidData Android { get; set; }

        [JsonProperty("config")]
        public AdCreativeConfigData Config { get; set; }

        [JsonProperty("ios")]
        public AdCreativeIosData iOS { get; set; }

        [JsonProperty("ipad")]
        public AdCreativeIpadData iPad { get; set; }

        [JsonProperty("iphone")]
        public AdCreativeIphoneData iPhone { get; set; }

        [JsonProperty("web")]
        public AdCreativeWebData Web { get; set; }

        [JsonProperty("windows_phone")]
        public AdCreativeWindowsPhoneData WindowsPhone { get; set; }
    }
}
