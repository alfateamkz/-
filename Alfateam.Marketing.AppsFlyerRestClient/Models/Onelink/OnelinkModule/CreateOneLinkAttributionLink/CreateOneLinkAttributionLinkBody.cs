using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.OnelinkModule.CreateOneLinkAttributionLink
{
    public class CreateOneLinkAttributionLinkBody
    {
        [JsonProperty("brand_domain")]
        public string BrandDomain { get; set; }

        [JsonProperty("ttl")]
        public string TTL { get; set; }

        [JsonProperty("data")]
        public string DataJSON { get; set; }
    }
}
