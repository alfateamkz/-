using Alfateam.Marketing.YandexDirectRestClient.Models.NegativeKeywordSharedSets.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.NegativeKeywordSharedSets.Update
{
    public class NegativeKeywordSharedSetsUpdateParamsBody
    {
        [JsonProperty("NegativeKeywordSharedSets")]
        public List<NegativeKeywordSharedSetUpdateItem> NegativeKeywordSharedSets { get; set; } = new List<NegativeKeywordSharedSetUpdateItem>();
    }
}
