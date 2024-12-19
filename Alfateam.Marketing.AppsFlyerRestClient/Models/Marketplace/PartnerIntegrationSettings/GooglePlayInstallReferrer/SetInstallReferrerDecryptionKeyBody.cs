using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.GooglePlayInstallReferrer
{
    public class SetInstallReferrerDecryptionKeyBody
    {

        [JsonProperty("pid")]
        public string Pid { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("general_params")]
        public SetInstallReferrerDecryptionKeyBodyGeneralParams GeneralParams { get; set; }
    }
}
