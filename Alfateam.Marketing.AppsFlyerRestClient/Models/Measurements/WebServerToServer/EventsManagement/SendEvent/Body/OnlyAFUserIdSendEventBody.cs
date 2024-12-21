using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.Measurements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.WebServerToServer.EventsManagement.SendEvent.Body
{
    public class OnlyAFUserIdSendEventBody : WSToSEventManagementSendEventBody
    {
        [JsonProperty("afUserId")]
        public string AfUserId { get; set; }
    }
}
