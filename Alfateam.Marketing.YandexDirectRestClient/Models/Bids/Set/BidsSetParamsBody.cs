using Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Get;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Set
{
    public class BidsSetParamsBody
    {
        [JsonProperty("Bids")]
        public List<BidSetItem> Bids { get; set; } = new List<BidSetItem>();
    }
}
