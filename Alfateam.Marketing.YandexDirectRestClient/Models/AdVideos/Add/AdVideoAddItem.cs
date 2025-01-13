using Alfateam.Marketing.YandexDirectRestClient.Enums.AdVideos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdVideos.Add
{
    public class AdVideoAddItem
    {
        [JsonProperty("Url")]
        public string URL { get; set; }

        [JsonProperty("VideoData")]
        public string VideoDataBase64 { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
