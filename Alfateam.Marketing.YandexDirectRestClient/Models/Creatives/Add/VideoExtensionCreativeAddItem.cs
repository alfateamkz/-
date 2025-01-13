using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives.Add
{
    public class VideoExtensionCreativeAddItem
    {
        [JsonProperty("VideoId")]
        public string VideoId { get; set; }
    }
}
