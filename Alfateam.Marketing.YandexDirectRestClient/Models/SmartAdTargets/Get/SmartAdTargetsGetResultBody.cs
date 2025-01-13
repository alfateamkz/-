using Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets.Get
{
    public class SmartAdTargetsGetResultBody
    {
        [JsonProperty("SmartAdTargets")]
        public List<SmartAdTargetGetItem> SmartAdTargets { get; set; } = new List<SmartAdTargetGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}
