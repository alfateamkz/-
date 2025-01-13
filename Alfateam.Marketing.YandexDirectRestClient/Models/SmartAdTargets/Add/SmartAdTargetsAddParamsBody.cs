using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.SmartAdTargets.Add
{
    public class SmartAdTargetsAddParamsBody
    {
        [JsonProperty("SmartAdTargets")]
        public List<SmartAdTargetAddItem> SmartAdTargets { get; set; } = new List<SmartAdTargetAddItem>();
    }
}
