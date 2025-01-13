using Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.RetargetingLists.Update
{
    public class RetargetingListsUpdateParamsBody
    {
        [JsonProperty("RetargetingLists")]
        public List<RetargetingListUpdateItem> RetargetingLists { get; set; } = new List<RetargetingListUpdateItem>();
    }
}
