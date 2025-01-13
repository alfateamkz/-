using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AudienceTargets.Get
{
    public class AudienceTargetsGetResultBody
    {
        [JsonProperty("AudienceTargets")]
        public List<AudienceTargetGetItem> AudienceTargets { get; set; } = new List<AudienceTargetGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}
