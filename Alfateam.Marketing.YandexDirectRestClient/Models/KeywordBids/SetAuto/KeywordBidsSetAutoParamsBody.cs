using Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Set;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.SetAuto
{
    public class KeywordBidsSetAutoParamsBody
    {
        [JsonProperty("KeywordBids")]
        public List<KeywordBidSetAutoItem> KeywordBids { get; set; } = new List<KeywordBidSetAutoItem>();
    }
}
