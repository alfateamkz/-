using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists.Add
{
    public class RetargetingListsAddParamsBody
    {
        [JsonProperty("RetargetingLists")]
        public List<RetargetingListAddItem> RetargetingLists { get; set; } = new List<RetargetingListAddItem>();
    }
}
