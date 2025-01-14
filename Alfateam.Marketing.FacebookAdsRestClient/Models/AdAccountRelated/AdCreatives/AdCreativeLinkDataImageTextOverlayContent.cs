using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeLinkDataImageTextOverlayContent
    {
        //TODO: AdCreativeLinkDataImageTextOverlayContent field type

        [JsonProperty("type")]
        public object type { get; set; }

        [JsonProperty("price")]
        public object price { get; set; }

        [JsonProperty("low_price")]
        public object low_price { get; set; }

        [JsonProperty("high_price")]
        public object high_price { get; set; }

        [JsonProperty("auto_show_enroll_status")]
        public object auto_show_enroll_status { get; set; }
    }
}
