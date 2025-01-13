using Alfateam.Marketing.YandexDirectRestClient.Enums.RetargetingLists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists.Get
{
    public class RetargetingListSelectionCriteria : IdsCriteria
    {
        [JsonProperty("Types")]
        public List<RetargetingListTypeEnum> Types { get; set; } = new List<RetargetingListTypeEnum>();
    }
}
