using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.AdCreatives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeAssetGroupTextSpec
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("text_type")]
        public AdCreativeAssetGroupTextSpecType TextType { get; set; }
    }
}
