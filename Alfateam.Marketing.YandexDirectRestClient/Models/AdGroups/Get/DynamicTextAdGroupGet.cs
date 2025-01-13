using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Get
{
    public class DynamicTextAdGroupGet
    {
        [JsonProperty("DomainUrl")]
        public string DomainUrl { get; set; }

        [JsonProperty("DomainUrlProcessingStatus")]
        public DomainUrlProcessingStatus DomainUrlProcessingStatus { get; set; }

        [JsonProperty("AutotargetingCategories")]
        public AutotargetingCategoriesGet AutotargetingCategories { get; set; }
    }
}
