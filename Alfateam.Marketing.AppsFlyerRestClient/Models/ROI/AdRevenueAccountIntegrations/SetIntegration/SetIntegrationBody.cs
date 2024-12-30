using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.SetIntegration
{
    public class SetIntegrationBody
    {
        [JsonProperty("integrations")]
        public List<AdRevenueAccountIntegration> Integrations { get; set; } = new List<AdRevenueAccountIntegration>();
    }
}
