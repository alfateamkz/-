using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeAssetGroupSpec
    {
        [JsonProperty("call_to_action")]
        public AdCreativeLinkDataCallToAction CallToAction { get; set; }

        [JsonProperty("group_uuid")]
        public string GroupUUID { get; set; }

        [JsonProperty("images")]
        public List<AdCreativeAssetGroupImageSpec> Images { get; set; } = new List<AdCreativeAssetGroupImageSpec>();

        [JsonProperty("texts")]
        public List<AdCreativeAssetGroupTextSpec> Texts { get; set; } = new List<AdCreativeAssetGroupTextSpec>();

        [JsonProperty("videos")]
        public List<AdCreativeAssetGroupVideoSpec> Videos { get; set; } = new List<AdCreativeAssetGroupVideoSpec>();
    }
}
