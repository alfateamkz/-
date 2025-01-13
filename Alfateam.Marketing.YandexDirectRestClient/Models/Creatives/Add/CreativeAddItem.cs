using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Add
{
    public class CreativeAddItem
    {
        [JsonProperty("VideoExtensionCreative")]
        public List<VideoExtensionCreativeAddItem> VideoExtensionCreative { get; set; } = new List<VideoExtensionCreativeAddItem>();
    }
}
