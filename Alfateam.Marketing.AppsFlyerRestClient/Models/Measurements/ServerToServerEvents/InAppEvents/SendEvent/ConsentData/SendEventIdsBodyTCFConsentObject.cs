using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.ServerToServerEvents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.ServerToServerEvents.InAppEvents.SendEvent.ConsentData
{
    public class SendEventIdsBodyTCFConsentObject
    {
        [JsonProperty("policy_version")]
        public int PolicyVersion { get; set; }

        [JsonProperty("gdpr_applies")]
        public SendEventIdsBodyTCFConsentGdprApplies GDPRApplies { get; set; }

        [JsonProperty("cmp_sdk_id")]
        public int CmpSdkId { get; set; }

        [JsonProperty("cmp_sdk_version")]
        public int CmpSDKVersion { get; set; }

        [JsonProperty("tcstring")]
        public string Tcstring { get; set; }
    }
}
