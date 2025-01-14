using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class AdsImageCrops
    {
        [JsonProperty("100x100")]
        public AdsImageCropsBounds Crop100x100 { get; set; }

        [JsonProperty("100x72")]
        public AdsImageCropsBounds Crop100x72 { get; set; }

        [JsonProperty("400x150")]
        public AdsImageCropsBounds Crop400x150 { get; set; }

        [JsonProperty("400x500")]
        public AdsImageCropsBounds Crop400x500 { get; set; }

        [JsonProperty("600x360")]
        public AdsImageCropsBounds Crop600x360 { get; set; }

        [JsonProperty("90x160")]
        public AdsImageCropsBounds Crop90x160 { get; set; }
    }
}
