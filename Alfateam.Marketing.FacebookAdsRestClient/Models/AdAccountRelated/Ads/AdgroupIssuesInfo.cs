using Alfateam.Marketing.FacebookAdsRestClient.Enums.AdAccountRelated.Ads;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.FacebookAdsRestClient.Models.AdAccountRelated.Ads
{
    public class AdgroupIssuesInfo
    {
        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("error_summary")]
        public string ErrorSummary { get; set; }

        [JsonProperty("error_type")]
        public AdgroupIssuesInfoErrorType ErrorType { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }
    }
}
