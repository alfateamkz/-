using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.Incost.IncostJobStatus
{
    public class GetJobStatusResponseErrorObject
    {
        [JsonProperty("af_error_code")]
        public DateOnly AfErrorCode { get; set; }

        [JsonProperty("error_message")]
        public DateOnly ErrorMessage { get; set; }
    }
}
