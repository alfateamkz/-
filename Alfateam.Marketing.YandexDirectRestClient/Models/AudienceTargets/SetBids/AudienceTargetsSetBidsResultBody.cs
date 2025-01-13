using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AudienceTargets.SetBids
{
    public class AudienceTargetsSetBidsResultBody
    {
        [JsonProperty("SetBidsResults")]
        public List<SetBidsActionResult> SetBidsResults { get; set; } = new List<SetBidsActionResult>();
    }
}
