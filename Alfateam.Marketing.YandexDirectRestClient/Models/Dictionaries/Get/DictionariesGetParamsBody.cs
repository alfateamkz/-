using Alfateam.Marketing.YandexDirectRestClient.Enums.Dictionaries;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Dictionaries.Get
{
    public class DictionariesGetParamsBody
    {
        [JsonProperty("DictionaryNames")]
        public List<DictionaryNameEnum> DictionaryNames { get; set; } = new List<DictionaryNameEnum>();
    }
}
