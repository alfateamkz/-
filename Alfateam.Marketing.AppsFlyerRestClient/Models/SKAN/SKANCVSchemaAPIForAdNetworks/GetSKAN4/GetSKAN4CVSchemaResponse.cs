using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.SKAN;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN4
{
    public class GetSKAN4CVSchemaResponse
    {
        [JsonProperty("data")]
        public GetSKAN4CVSchemaResponseData Data { get; set; }
    }
}
