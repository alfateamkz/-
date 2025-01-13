using Alfateam.Marketing.YandexDirectRestClient.Enums.TurboPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.TurboPages.Get
{
    public class TurboPagesGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public TurboPagesGetSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<TurboPageFieldEnum> FieldNames { get; set; } = Enum.GetValues<TurboPageFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
