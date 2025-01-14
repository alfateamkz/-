using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.AdCreatives
{
    public class AdCreativeDegreesOfFreedomSpec
    {
        [JsonProperty("creative_features_spec")]
        public AdCreativeFeaturesSpec CreativeFeaturesSpec { get; set; }
    }
}
