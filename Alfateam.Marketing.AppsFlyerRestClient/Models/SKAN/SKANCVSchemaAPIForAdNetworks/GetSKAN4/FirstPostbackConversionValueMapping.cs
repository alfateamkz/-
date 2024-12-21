using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN4
{
    public class FirstPostbackConversionValueMapping
    {
        [JsonProperty("fine")]
        public List<FirstPostbackConversionValueMappingFine> Fine { get; set; } = new List<FirstPostbackConversionValueMappingFine>();
   
        [JsonProperty("coarse")]
        public PostbackConversionValueCoarse Coarse { get; set; }
    }
}
