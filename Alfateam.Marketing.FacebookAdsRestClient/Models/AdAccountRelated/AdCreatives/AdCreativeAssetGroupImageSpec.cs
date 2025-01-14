using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeAssetGroupImageSpec
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("image_crops")]
        public AdsImageCrops ImageCrops { get; set; }

        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
