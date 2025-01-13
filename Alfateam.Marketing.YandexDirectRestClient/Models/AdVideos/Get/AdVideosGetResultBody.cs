using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdVideos.Get
{
    public class AdVideosGetResultBody
    {
        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }

        [JsonProperty("AdVideos")]
        public List<AdVideoGetItem> AdVideos { get; set; } = new List<AdVideoGetItem>();
    }
}
