using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries
{
    public class DictionariesParams<T>
    {
        [JsonProperty("method")]
        public DictionariesMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
