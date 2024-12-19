using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.UniquePartnerIntegrationParameters
{
    public class GetAListOfUniqueParametersResponse
    {
        [JsonProperty("general_params")]
        public GetAListOfUniqueParametersResponseGeneralParams GeneralParams { get; set; }

        [JsonProperty("in_app_postbacks_params")]
        public GetAListOfUniqueParametersResponseInAppPostbacksParams InAppPostbacksParams { get; set; }
    }
}
