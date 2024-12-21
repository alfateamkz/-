using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.WebServerToServer.EventsManagement.AssociateCustomerUserID
{
    public class AssociateCustomerUserIDBody
    {
        [JsonProperty("customerUserId")]
        public string CustomerUserId { get; set; }

        [JsonProperty("afUserId")]
        public string AfUserId { get; set; }

        [JsonProperty("webDevKey")]
        public string WebDevKey { get; set; }
    }
}
