using Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Set;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.SetAuto
{
    public class BidsSetAutoParamsBody
    {
        [JsonProperty("Bids")]
        public List<BidSetAutoItem> Bids { get; set; } = new List<BidSetAutoItem>();
    }
}
