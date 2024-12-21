using Alfateam.Marketing.AppsFlyerRestClient.Enums.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations
{
    public class AdRevenueAccountIntegrationProduct
    {
        [JsonProperty("name")]
        public AdRevenueAccountIntegrationProductNameType Name { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("source_event")]
        public string SourceEvent { get; set; }
    }
}
