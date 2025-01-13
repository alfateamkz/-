using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.NegativeKeywordSharedSets.Get
{
    public class NegativeKeywordSharedSetGetItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("NegativeKeywords")]
        public List<string> NegativeKeywords { get; set; } = new List<string>();

        [JsonProperty("Associated")]
        public YesNoEnum Associated { get; set; }
    }
}
