using Alfateam.Marketing.YandexDirectRestClient.Enums.TurboPages;
using Alfateam.Marketing.YandexDirectRestClient.Enums.VCards;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.VCards
{
    public class VCardsParams<T>
    {
        [JsonProperty("method")]
        public VCardsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
