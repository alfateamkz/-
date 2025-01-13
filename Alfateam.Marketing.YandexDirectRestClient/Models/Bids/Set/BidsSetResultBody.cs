using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.Set
{
    public class BidsSetResultBody
    {
        [JsonProperty("SetResults")]
        public List<BidActionResult> SetResults { get; set; } = new List<BidActionResult>();
    }
}
