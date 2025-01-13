using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdVideos.Add
{
    public class AdVideosAddParamsBody
    {
        [JsonProperty("AdVideos")]
        public List<AdVideoAddItem> AdVideos { get; set; } = new List<AdVideoAddItem>();
    }
}
