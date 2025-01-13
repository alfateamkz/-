using Alfateam.Marketing.YandexDirectRestClient.Enums.AdVideos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdVideos.Get
{
    public class AdVideoGetItem
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Status")]
        public AdVideoStatus Status { get; set; }
    }
}
