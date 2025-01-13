using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicFeedAdTargets.Add
{
    public class DynamicFeedAdTargetsAddParamsBody
    {
        [JsonProperty("DynamicFeedAdTargets")]
        public List<DynamicFeedAdTargetAddItem> DynamicFeedAdTargets { get; set; } = new List<DynamicFeedAdTargetAddItem>();
    }
}
