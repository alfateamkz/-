using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.AuthenticationToken.SetPushAPIAuthenticationToken
{
    public class SetPushAPIAuthenticationTokenResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
