using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.General
{
    public class VoipInfo
    {
        [JsonProperty("has_mobile_app")]
        public bool HasMobileApp { get; set; }

        [JsonProperty("has_permission")]
        public bool HasPermission { get; set; }

        [JsonProperty("is_callable")]
        public bool IsCallable { get; set; }

        [JsonProperty("is_callable_webrtc")]
        public bool IsCallableWebRTC { get; set; }

        [JsonProperty("is_pushable")]
        public bool IsPushable { get; set; }

        [JsonProperty("reason_code")]
        public uint ReasonCode { get; set; }

        [JsonProperty("reason_description")]
        public string ReasonDescription { get; set; }
    }
}
