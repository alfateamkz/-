using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AudienceTargets.SetBids
{
    public class AudienceTargetsSetBidsParamsBody
    {
        [JsonProperty("Bids")]
        public List<AudienceTargetSetBidsItem> Bids { get; set; } = new List<AudienceTargetSetBidsItem>();
    }
}
