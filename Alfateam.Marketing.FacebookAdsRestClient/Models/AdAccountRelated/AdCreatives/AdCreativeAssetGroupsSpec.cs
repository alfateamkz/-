using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeAssetGroupsSpec
    {
        [JsonProperty("groups")]
        public List<AdCreativeAssetGroupSpec> Groups { get; set; } = new List<AdCreativeAssetGroupSpec>();
    }
}
