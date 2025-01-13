using Alfateam.Marketing.YandexDirectRestClient.Enums.Businesses;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Changes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Businesses
{
    public class BusinessesParams<T>
    {
        [JsonProperty("method")]
        public BusinessesMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
