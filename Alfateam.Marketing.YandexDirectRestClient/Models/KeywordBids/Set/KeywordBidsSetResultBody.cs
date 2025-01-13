using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.Set
{
    public class KeywordBidsSetResultBody
    {
        [JsonProperty("SetResults")]
        public List<KeywordBidActionResult> SetResults { get; set; } = new List<KeywordBidActionResult>();
    }
}
