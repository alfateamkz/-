using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Get
{
    public class KeywordBidSearch
    {
        [JsonProperty("Bid")]
        public long Bid { get; set; }

        [JsonProperty("AutotargetingSearchBidIsAuto")]
        public YesNoEnum AutotargetingSearchBidIsAuto { get; set; }

        [JsonProperty("AuctionBids")]
        public AuctionBids AuctionBids { get; set; }
    }
}
