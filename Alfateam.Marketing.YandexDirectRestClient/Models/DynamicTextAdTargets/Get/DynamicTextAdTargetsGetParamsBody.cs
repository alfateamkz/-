using Alfateam.Marketing.YandexDirectRestClient.Enums.DynamicTextAdTargets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.DynamicTextAdTargets.Get
{
    public class DynamicTextAdTargetsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public WebpagesSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<WebpageFieldEnum> FieldNames { get; set; } = Enum.GetValues<WebpageFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
