using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class DynamicTextFeedAdGroupGet
    {
        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("FeedId")]
        public long FeedId { get; set; }

        [JsonProperty("SourceType")]
        public SourceType SourceType { get; set; }

        [JsonProperty("SourceProcessingStatus")]
        public SourceProcessingStatus SourceProcessingStatus { get; set; }

        [JsonProperty("AutotargetingCategories")]
        public AutotargetingCategoriesGet AutotargetingCategories { get; set; }
    }
}
