using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.SKAN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN4.Postbacks
{
    public class SKAN4CVSchemaNotFirstPostback : GetSKAN4CVSchemaResponsePostback
    {
        [JsonProperty("conversion_value_mapping")]
        public NotFirstPostbackConversionValueMapping ConversionValueMapping { get; set; }
    }
}
