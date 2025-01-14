using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated
{
    public class CustomAudienceGroup
    {
        [JsonProperty("audience_type_param_name")]
        public string AudienceTypeParamName { get; set; }

        [JsonProperty("existing_customer_tag")]
        public string ExistingCustomerTag { get; set; }

        [JsonProperty("new_customer_tag")]
        public string NewCustomerTag { get; set; }
    }
}
