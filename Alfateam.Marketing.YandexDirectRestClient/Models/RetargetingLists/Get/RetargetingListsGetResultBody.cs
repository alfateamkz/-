using Alfateam.Marketing.YandexDirectRestClient.Enums.AdGroups;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists.Get
{
    public class RetargetingListsGetResultBody
    {
        [JsonProperty("RetargetingLists")]
        public List<RetargetingListGetItem> RetargetingLists { get; set; } = new List<RetargetingListGetItem>();

        [JsonProperty("LimitedBy")]
        public long LimitedBy { get; set; }
    }
}
