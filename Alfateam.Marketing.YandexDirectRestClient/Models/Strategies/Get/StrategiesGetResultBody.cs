using Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Strategies.Get
{
    public class StrategiesGetResultBody
    {
        [JsonProperty("Strategies")]
        public List<StrategiesGetItem> Strategies { get; set; } = new List<StrategiesGetItem>();
    }
}
