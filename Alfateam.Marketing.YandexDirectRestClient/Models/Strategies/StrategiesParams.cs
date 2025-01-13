using Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies;
using Alfateam.Marketing.YandexDirectRestClient.Enums.VCards;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies
{
    public class StrategiesParams<T>
    {
        [JsonProperty("method")]
        public StrategiesMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
