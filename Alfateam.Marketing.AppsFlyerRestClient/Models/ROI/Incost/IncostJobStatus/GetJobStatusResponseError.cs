using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.Incost.IncostJobStatus
{
    public class GetJobStatusResponseError
    {
        [JsonProperty("error")]
        public GetJobStatusResponseErrorObject Error { get; set; }
    }
}
