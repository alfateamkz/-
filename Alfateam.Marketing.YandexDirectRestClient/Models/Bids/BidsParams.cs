using Alfateam.Marketing.YandexDirectRestClient.Enums.Bids;
using Alfateam.Marketing.YandexDirectRestClient.Enums.Businesses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids
{
    public class BidsParams<T>
    {
        [JsonProperty("method")]
        public BidsMethod Method { get; set; }

        [JsonProperty("params")]
        public T Params { get; set; }
    }
}
