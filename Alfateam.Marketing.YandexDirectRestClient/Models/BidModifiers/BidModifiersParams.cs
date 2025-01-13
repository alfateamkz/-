using Alfateam.Marketing.YandexDirectRestClient.Enums.AudienceTargets;
using Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.BidModifiers
{
    public class BidModifiersParams<T>
    {
        [JsonProperty("method")]
        public BidModifiersMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
