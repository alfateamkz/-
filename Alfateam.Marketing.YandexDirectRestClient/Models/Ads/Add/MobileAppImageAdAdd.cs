using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class MobileAppImageAdAdd
    {
        [JsonProperty("AdImageHash")]
        public string AdImageHash { get; set; }

        [JsonProperty("ErirAdDescription")]
        public string ErirAdDescription { get; set; }

        [JsonProperty("TrackingUrl")]
        public string TrackingUrl { get; set; }
    }
}
