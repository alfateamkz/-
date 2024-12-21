using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppManagementAPIV2.AppManagement.UpdateApp
{
    public class UpdateAppBodyReEngagementAttribution
    {
        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("minTimeBetweenReEngagements")]
        public int MinTimeBetweenReEngagements { get; set; }
    }
}
