using Alfateam.Marketing.YandexDirectRestClient.Enums.Ads;
using Alfateam.Marketing.YandexDirectRestClient.Enums.SmartAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets
{
    public class SmartAdTargetsParams<T>
    {
        [JsonProperty("method")]
        public SmartAdTargetsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
