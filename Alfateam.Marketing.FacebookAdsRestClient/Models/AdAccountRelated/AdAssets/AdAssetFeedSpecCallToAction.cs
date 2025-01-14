using Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetFeedSpecCallToAction
    {
        [JsonProperty("adlabels")]
        public List<AdAssetFeedSpecAssetLabel> AdLabels { get; set; } = new List<AdAssetFeedSpecAssetLabel>();

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public AdCreativeLinkDataCallToActionValue Value { get; set; }
    }
}
