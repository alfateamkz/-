using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Add
{
    public class DynamicTextFeedAdGroupAdd
    {
        [JsonProperty("FeedId")]
        public long FeedId { get; set; }

        [JsonProperty("AutotargetingCategories")]
        public List<AutotargetingCategoriesAdd> AutotargetingCategories { get; set; } = new List<AutotargetingCategoriesAdd>();
    }
}
