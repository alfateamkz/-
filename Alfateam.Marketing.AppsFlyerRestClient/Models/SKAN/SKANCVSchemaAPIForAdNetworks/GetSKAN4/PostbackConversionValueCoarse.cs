using Alfateam.Marketing.AppsFlyerRestClient.Enums.SKAN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN4
{
    public class PostbackConversionValueCoarse
    {
        [JsonProperty("conversion_value")]
        public PostbackConversionValueCoarseConversionValue ConversionValue { get; set; }

        [JsonProperty("min_time_post_install")]
        public int MinTimePostInstall { get; set; }

        [JsonProperty("max_time_post_install")]
        public int MaxTimePostInstall { get; set; }

        [JsonProperty("events")]
        public List<PostbackConversionValueCoarseEvent> Events { get; set; } = new List<PostbackConversionValueCoarseEvent>();
    }
}
