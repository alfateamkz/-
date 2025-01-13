using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets.SetBids
{
    public class SmartAdTargetsSetBidsParamsBody
    {
        [JsonProperty("Bids")]
        public List<SetBidsItem> Bids { get; set; } = new List<SetBidsItem>();
    }
}
