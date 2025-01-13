using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Get
{
    public class KeywordBidNetwork
    {
        [JsonProperty("Bid")]
        public long Bid { get; set; }

        [JsonProperty("Coverage")]
        public KeywordBidNetworkCoverage Coverage { get; set; }
    }
}
