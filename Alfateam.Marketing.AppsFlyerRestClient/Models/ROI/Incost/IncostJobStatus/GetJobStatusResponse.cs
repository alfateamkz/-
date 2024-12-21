using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.Incost.IncostJobStatus
{
    public class GetJobStatusResponse
    {
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("uploaded_request_url")]
        public string UploadedRequestURL { get; set; }

        [JsonProperty("error")]
        public GetJobStatusResponseError Error { get; set; }

        [JsonProperty("date_from")]
        public string Datefrom { get; set; }

        [JsonProperty("date_to")]
        public string DateTo { get; set; }

        [JsonProperty("matched_records_percentage")]
        public string MatchedRecordsPercentage { get; set; }

        [JsonProperty("agency")]
        public string Agency { get; set; }
    }
}
