using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls.UploadCalls
{
    public class UploadCallsQueryParameters
    {
        [JsonProperty("client_id_type")]
        public ClientIdType ClientIdType { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("new_goal_name")]
        public string NewGoalName { get; set; }
    }
}
