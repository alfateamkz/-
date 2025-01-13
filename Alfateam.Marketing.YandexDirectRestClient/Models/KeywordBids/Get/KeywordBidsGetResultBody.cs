using Alfateam.Marketing.YandexDirectRestClient.Enums.KeywordBids;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Get
{
    public class KeywordBidsGetResultBody
    {
        [JsonProperty("KeywordBids")]
        public List<KeywordBidGetItem> KeywordBids { get; set; } = new List<KeywordBidGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}
