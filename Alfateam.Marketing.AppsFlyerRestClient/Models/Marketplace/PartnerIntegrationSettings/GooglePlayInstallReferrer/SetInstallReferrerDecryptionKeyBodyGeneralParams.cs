using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.GooglePlayInstallReferrer
{
    public class SetInstallReferrerDecryptionKeyBodyGeneralParams
    {
        [JsonProperty("gp_referrer_decryption_key")]
        public string GPReferrerDecryptionKey { get; set; }
    }
}
