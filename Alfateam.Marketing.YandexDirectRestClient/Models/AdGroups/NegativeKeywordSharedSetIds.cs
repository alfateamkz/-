using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups
{
    public class NegativeKeywordSharedSetIds
    {
        [JsonProperty("Items")]
        public List<long> Items { get; set; } = new List<long>();
    }
}
