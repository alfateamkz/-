using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppManagementAPIV2.AppManagement.AddApp
{
    public class AddAppResponse
    {
        [JsonProperty("data")]
        public AddAppResponseData Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public AppManagementResponseError Error { get; set; }
    }
}
