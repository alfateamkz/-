using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Add
{
    public class FileFeedAdd
    {
        [JsonProperty("Data")]
        public string DataBase64 { get; set; }

        [JsonProperty("Filename")]
        public string Filename { get; set; }
    }
}
