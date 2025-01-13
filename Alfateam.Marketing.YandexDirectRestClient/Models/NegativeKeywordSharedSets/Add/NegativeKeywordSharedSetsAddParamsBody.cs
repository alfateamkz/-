using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.NegativeKeywordSharedSets.Add
{
    public class NegativeKeywordSharedSetsAddParamsBody
    {
        [JsonProperty("NegativeKeywordSharedSets")]
        public List<NegativeKeywordSharedSetAddItem> NegativeKeywordSharedSets { get; set; } = new List<NegativeKeywordSharedSetAddItem>();
    }
}
