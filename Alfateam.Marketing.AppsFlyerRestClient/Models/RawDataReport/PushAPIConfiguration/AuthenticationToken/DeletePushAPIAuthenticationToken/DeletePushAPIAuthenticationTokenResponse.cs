using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.AuthenticationToken.DeletePushAPIAuthenticationToken
{
    public class DeletePushAPIAuthenticationTokenResponse
    {
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
