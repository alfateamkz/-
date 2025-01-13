using Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Changes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Changes
{
    public class ChangesParams<T>
    {
        [JsonProperty("method")]
        public ChangesMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
