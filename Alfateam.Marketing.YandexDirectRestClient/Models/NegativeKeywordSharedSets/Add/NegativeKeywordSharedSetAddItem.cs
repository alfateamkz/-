using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.NegativeKeywordSharedSets.Add
{
    public class NegativeKeywordSharedSetAddItem
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("NegativeKeywords")]
        public List<string> NegativeKeywords { get; set; } = new List<string>();
    }
}
