using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists.Update
{
    public class RetargetingListUpdateItem
    {
        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Rules")]
        public List<RetargetingListRuleItem> Rules { get; set; } = new List<RetargetingListRuleItem>();
    }
}
