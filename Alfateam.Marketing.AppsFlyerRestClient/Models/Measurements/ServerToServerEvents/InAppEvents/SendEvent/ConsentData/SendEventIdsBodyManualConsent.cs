using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.Measurements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.ServerToServerEvents.InAppEvents.SendEvent.ConsentData
{
    public class SendEventIdsBodyManualConsent : SendEventIdsBodyConsentData
    {
        [JsonProperty("manual")]
        public SendEventIdsBodyManualConsentObject Manual { get; set; }
    }
}
