using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.AuthenticationToken.SetPushAPIAuthenticationToken
{
    public class SetPushAPIAuthenticationTokenBody
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("token_name")]
        public string TokenName { get; set; }
    }
}
