using Alfateam.Marketing.YandexDirectRestClient.Enums.Creatives;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Creatives
{
    public class CreativesParams<T>
    {
        [JsonProperty("method")]
        public CreativesMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
