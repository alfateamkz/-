using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads.Add
{
    public class TextImageAdAdd
    {
        [JsonProperty("AdImageHash")]
        public string AdImageHash { get; set; }

        [JsonProperty("ErirAdDescription")]
        public string ErirAdDescription { get; set; }

        [JsonProperty("Href")]
        public string Href { get; set; }

        [JsonProperty("TurboPageId")]
        public long TurboPageId { get; set; }
    }
}
