using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.Credentials
{
    public class ApplovinmaxNetworkCredentials : AdRevenueAccountIntegrationNetworkCredentials
    {
        [JsonProperty("report_key")]
        public string ReportKey { get; set; }

        [JsonProperty("package_name")]
        public string PackageName { get; set; }
    }
}
