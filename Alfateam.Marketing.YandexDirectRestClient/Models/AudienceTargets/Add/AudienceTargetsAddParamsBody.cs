using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AudienceTargets.Add
{
    public class AudienceTargetsAddParamsBody
    {
        [JsonProperty("AudienceTargets")]
        public List<AudienceTargetAddItem> AudienceTargets { get; set; } = new List<AudienceTargetAddItem>();
    }
}
