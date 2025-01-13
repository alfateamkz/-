using Alfateam.Marketing.YandexDirectRestClient.Enums.RetargetingLists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists.Get
{
    public class RetargetingListsGetParamsBody
    {
        [JsonProperty("SelectionCriteria")]
        public RetargetingListSelectionCriteria SelectionCriteria { get; set; }

        [JsonProperty("FieldNames")]
        public List<RetargetingListFieldEnum> FieldNames { get; set; } = Enum.GetValues<RetargetingListFieldEnum>().ToList();

        [JsonProperty("Page")]
        public LimitOffset Page { get; set; }
    }
}
