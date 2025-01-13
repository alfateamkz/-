using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.SetAuto
{
    public class KeywordBidSetAutoItem
    {
        [JsonProperty("CampaignId")]
        public long CampaignId { get; set; }

        [JsonProperty("AdGroupId")]
        public long AdGroupId { get; set; }

        [JsonProperty("KeywordId")]
        public long KeywordId { get; set; }

        [JsonProperty("BiddingRule")]
        public BiddingRule BiddingRule { get; set; }
    }
}
