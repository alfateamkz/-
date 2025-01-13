using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AdGroups.Add
{
    public class AdGroupsAddParamsBody
    {
        [JsonProperty("AdGroups")]
        public List<AdGroupAddItem> AdGroups { get; set; } = new List<AdGroupAddItem>();
    }
}
