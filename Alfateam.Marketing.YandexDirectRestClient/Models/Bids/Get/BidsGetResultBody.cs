using Alfateam.Marketing.YandexDirectRestClient.Enums.Bids;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Get
{
    public class BidsGetResultBody
    {
        [JsonProperty("Bids")]
        public List<BidGetItem> Bids { get; set; } = new List<BidGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}
