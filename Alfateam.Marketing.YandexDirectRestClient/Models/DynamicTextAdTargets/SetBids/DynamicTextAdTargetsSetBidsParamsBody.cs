using Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.Get;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.SetBids
{
    public class DynamicTextAdTargetsSetBidsParamsBody
    {
        [JsonProperty("Bids")]
        public List<SetBidsItem> Bids { get; set; } = new List<SetBidsItem>();
    }
}
