using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdAssets
{
    public class AdAssetFeedSpecCaption
    {
        [JsonProperty("adlabels")]
        public List<AdAssetFeedSpecAssetLabel> AdLabels { get; set; } = new List<AdAssetFeedSpecAssetLabel>();

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("url_tags")]
        public string URLTags { get; set; }
    }
}
