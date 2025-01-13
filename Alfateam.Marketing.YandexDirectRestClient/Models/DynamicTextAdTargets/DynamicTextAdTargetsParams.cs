using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicFeedAdTargets;
using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicTextAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets
{
    public class DynamicTextAdTargetsParams<T>
    {
        [JsonProperty("method")]
        public DynamicTextAdTargetsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
