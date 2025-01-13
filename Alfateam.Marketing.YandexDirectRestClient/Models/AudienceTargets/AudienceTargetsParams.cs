using Alfateam.Marketing.YandexDirectRestClient.Enums.Ads;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AudienceTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AudienceTargets
{
    public class AudienceTargetsParams<T>
    {
        [JsonProperty("method")]
        public AudienceTargetsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
