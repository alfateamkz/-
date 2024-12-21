using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.ServerToServerEvents.InAppEvents.SendEvent.ConsentData
{
    public class SendEventIdsBodyManualConsentObject
    {
        [JsonProperty("gdpr_applies")]
        public bool GDPRApplies { get; set; }

        [JsonProperty("ad_user_data_enabled")]
        public bool AdUserDataEnabled { get; set; }

        [JsonProperty("ad_personalization_enabled")]
        public bool AdPersonalizationEnabled { get; set; }
    }
}
