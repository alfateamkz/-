using Alfateam.Marketing.YandexDirectRestClient.Enums.AdImages;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Ads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Ads
{
    public class AdsParams<T>
    {
        [JsonProperty("method")]
        public AdsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
