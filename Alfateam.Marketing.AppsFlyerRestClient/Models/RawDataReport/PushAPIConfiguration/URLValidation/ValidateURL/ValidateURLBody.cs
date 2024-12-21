using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.URLValidation.ValidateURL
{
    public class ValidateURLBody
    {
        [JsonProperty("url")]
        public string URL { get; set; }

        [JsonProperty("method")]
        public ValidateURLBodyMethod Method { get; set; }
    }
}
