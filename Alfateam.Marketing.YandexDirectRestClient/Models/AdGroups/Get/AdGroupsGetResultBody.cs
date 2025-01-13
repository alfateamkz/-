using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class AdGroupsGetResultBody
    {
        [JsonProperty("AdGroups")]
        public List<AdGroupGetItem> AdGroups { get; set; } = new List<AdGroupGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}
