using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.KeywordBids.SetAuto
{
    public class KeywordBidsSetAutoResultBody
    {
        [JsonProperty("SetAutoResults")]
        public List<KeywordBidActionResult> SetAutoResults { get; set; } = new List<KeywordBidActionResult>();
    }
}
