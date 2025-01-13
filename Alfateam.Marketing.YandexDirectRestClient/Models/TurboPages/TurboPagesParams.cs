using Alfateam.Marketing.YandexDirectRestClient.Enums.Changes;
using Alfateam.Marketing.YandexDirectRestClient.Enums.TurboPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.TurboPages
{
    public class TurboPagesParams<T>
    {
        [JsonProperty("method")]
        public TurboPagesMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
