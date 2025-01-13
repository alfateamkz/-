using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages.Get
{
    public class AdImagesGetResultBody
    {
        [JsonProperty("AdImages")]
        public List<AdImageGetItem> AdImages { get; set; } = new List<AdImageGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}
