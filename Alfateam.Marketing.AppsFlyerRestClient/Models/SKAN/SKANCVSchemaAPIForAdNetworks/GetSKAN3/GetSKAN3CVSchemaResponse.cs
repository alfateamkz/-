using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN3
{
    public class GetSKAN3CVSchemaResponse
    {
        [JsonProperty("data")]
        public GetSKAN3CVSchemaResponseData Data { get; set; }
    }
}
