using Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Add;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Update
{
    public class AdGroupsUpdateParamsBody
    {
        [JsonProperty("AdGroups")]
        public List<AdGroupUpdateItem> AdGroups { get; set; } = new List<AdGroupUpdateItem>();
    }
}
