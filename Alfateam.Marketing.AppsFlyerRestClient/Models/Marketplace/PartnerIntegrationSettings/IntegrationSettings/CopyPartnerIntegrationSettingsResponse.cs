using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.IntegrationSettings
{
    public class CopyPartnerIntegrationSettingsResponse
    {
        [JsonProperty("general_params")]
        public Dictionary<string, string> GeneralParams { get; set; } = new Dictionary<string, string>();

        [JsonProperty("in_app_postbacks_params")]
        public Dictionary<string, string> InAppPostbacksParams { get; set; } = new Dictionary<string, string>();
    }
}
