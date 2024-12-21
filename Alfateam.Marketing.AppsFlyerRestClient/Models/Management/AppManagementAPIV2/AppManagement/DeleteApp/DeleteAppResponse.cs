using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppManagementAPIV2.AppManagement.DeleteApp
{
    public class DeleteAppResponse
    {
        [JsonProperty("data")]
        public DeleteAppResponseData Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("error")]
        public AppManagementResponseError Error { get; set; }
    }
}
