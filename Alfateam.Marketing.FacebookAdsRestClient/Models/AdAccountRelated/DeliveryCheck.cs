using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class DeliveryCheck
    {
        [JsonProperty("check_name")]
        public DeliveryCheckName CheckName { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
