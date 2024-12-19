using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.GooglePlayInstallReferrer
{
    public class SetInstallReferrerDecryptionKeyResponseInAppPostbacksParams
    {
        [JsonProperty("mapped-in-app-events")]
        public SetInstallReferrerDecryptionKeyResponseMappedInAppEvents MappedInAppEvents { get; set; }
    }
}
