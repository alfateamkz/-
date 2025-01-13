using Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Update
{
    public class StrategiesAddUpdateBody
    {
        [JsonProperty("Strategies")]
        public List<StrategiesUpdateItem> Strategies { get; set; } = new List<StrategiesUpdateItem>();
    }
}
