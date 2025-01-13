using Alfateam.Marketing.YandexDirectRestClient.Abstractions.Models;
using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Update
{
    public class ClientsActionResult : AbsActionResult
    {
        [JsonProperty("ClientId")]
        public long ClientId { get; set; }
    }
}
