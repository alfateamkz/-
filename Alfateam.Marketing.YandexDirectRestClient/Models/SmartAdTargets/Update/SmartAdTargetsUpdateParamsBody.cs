using Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets.Update
{
    public class SmartAdTargetsUpdateParamsBody
    {
        [JsonProperty("SmartAdTargets")]
        public List<SmartAdTargetAddItem> SmartAdTargets { get; set; } = new List<SmartAdTargetAddItem>();
    }
}
