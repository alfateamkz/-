using Alfateam.Marketing.YandexDirectRestClient.Enums.AdImages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages.Add
{
    public class AdImageAddItem
    {
        [JsonProperty("ImageData")]
        public string ImageDataBase64 { get; set; }

        [JsonProperty("Type")]
        public AdImageAddTypeEnum Type { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
