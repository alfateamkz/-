using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AdImages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdImages
{
    public class AdImagesParams<T>
    {
        [JsonProperty("method")]
        public AdImagesMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
