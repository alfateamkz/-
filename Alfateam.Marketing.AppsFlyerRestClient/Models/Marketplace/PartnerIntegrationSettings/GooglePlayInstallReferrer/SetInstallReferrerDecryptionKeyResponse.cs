using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.GooglePlayInstallReferrer
{
    public class SetInstallReferrerDecryptionKeyResponse
    {
        [JsonProperty("general_params")]
        public SetInstallReferrerDecryptionKeyResponseGeneralParams GeneralParams { get; set; }

        [JsonProperty("in_app_postbacks_params")]
        public SetInstallReferrerDecryptionKeyResponseInAppPostbacksParams InAppPostbacksParams { get; set; }
    }
}
