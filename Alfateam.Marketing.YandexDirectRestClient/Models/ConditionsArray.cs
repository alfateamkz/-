using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class ConditionsArray
    {
        [JsonProperty("Items")]
        public List<ConditionsItem> Items { get; set; } = new List<ConditionsItem>();
    }
}
