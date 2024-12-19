using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.IntegrationSettings
{
    public class CopyPartnerIntegrationSettingsBody
    {
        [JsonProperty("pid")]
        public string Pid { get; set; }

        [JsonProperty("copy_from_app_id")]
        public string CopyFromAppId { get; set; }

        [JsonProperty("copy_to_app_id")]
        public string CopyToAppId { get; set; }

        [JsonProperty("general_params")]
        public Dictionary<string, string> GeneralParams { get; set; } = new Dictionary<string, string>();

        [JsonProperty("in_app_postbacks_params")]
        public Dictionary<string, string> InAppPostbacksParams { get; set; } = new Dictionary<string, string>();
    }
}
