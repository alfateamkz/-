using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Bids.SetAuto
{
    public class BidsSetAutoResultBody
    {
        [JsonProperty("SetAutoResults")]
        public List<BidActionResult> SetAutoResults { get; set; } = new List<BidActionResult>();
    }
}
