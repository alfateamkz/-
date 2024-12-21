using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.Incost.IncostUploader
{
    public class UploadCostDataResponse
    {
        [JsonProperty("job_id")]
        public string JobId { get; set; }
    }
}
