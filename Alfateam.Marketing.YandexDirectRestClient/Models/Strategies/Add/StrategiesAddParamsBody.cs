using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Add
{
    public class StrategiesAddParamsBody
    {
        [JsonProperty("Strategies")]
        public List<StrategiesAddItem> Strategies { get; set; } = new List<StrategiesAddItem>();
    }
}
