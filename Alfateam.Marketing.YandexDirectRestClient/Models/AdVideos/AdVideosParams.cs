using Alfateam.Marketing.YandexDirectRestClient.Enums.Ads;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AdVideos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdVideos
{
    public class AdVideosParams<T>
    {
        [JsonProperty("method")]
        public AdVideosMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
