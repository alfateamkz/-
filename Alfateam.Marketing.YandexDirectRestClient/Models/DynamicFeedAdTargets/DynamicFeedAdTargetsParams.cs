using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicFeedAdTargets;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Feeds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicFeedAdTargets
{
    public class DynamicFeedAdTargetsParams<T>
    {
        [JsonProperty("method")]
        public DynamicFeedAdTargetsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
