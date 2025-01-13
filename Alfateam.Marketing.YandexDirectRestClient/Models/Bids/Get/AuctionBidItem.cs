using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Get
{
    public class AuctionBidItem
    {
        [JsonProperty("Position")]
        public string Position { get; set; }

        [JsonProperty("Bid")]
        public long Bid { get; set; }

        [JsonProperty("Price")]
        public long Price { get; set; }
    }
}
