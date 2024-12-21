using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.Management;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppManagementAPIV2.AppManagement.AddApp.Body
{
    public class PendingAddAppBody : AddAppBody
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("app_id")]
        public string AppId { get; set; }
    }
}
