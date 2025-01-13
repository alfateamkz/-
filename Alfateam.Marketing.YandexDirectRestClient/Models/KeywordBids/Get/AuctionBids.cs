using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Get
{
    public class AuctionBids
    {
        [JsonProperty("AuctionBidItems")]
        public List<AuctionBidItem> AuctionBidItems { get; set; } = new List<AuctionBidItem>();
    }
}
