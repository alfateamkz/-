using Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Get;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Set
{
    public class KeywordBidsSetParamsBody
    {
        [JsonProperty("KeywordBids")]
        public List<KeywordBidSetItem> KeywordBids { get; set; } = new List<KeywordBidSetItem>();
    }
}
