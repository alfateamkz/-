using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.URLValidation.ValidateURL
{
    public class ValidateURLResponse
    {
        [JsonProperty("tested_endpoint_url_http_response")]
        public int TestedEndpointURLHTTPResponse { get; set; }
    }
}
