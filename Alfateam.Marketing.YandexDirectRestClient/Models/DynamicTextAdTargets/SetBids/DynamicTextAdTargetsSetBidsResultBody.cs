using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.SetBids
{
    public class DynamicTextAdTargetsSetBidsResultBody
    {
        [JsonProperty("SetBidsResults")]
        public List<SetBidsActionResult> SetBidsResults { get; set; } = new List<SetBidsActionResult>();
    }
}
