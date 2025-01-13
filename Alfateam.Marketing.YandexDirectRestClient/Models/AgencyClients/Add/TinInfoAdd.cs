using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Add
{
    public class TinInfoAdd
    {
        [JsonProperty("TinType")]
        public TinTypeEnum TINType { get; set; }

        [JsonProperty("Tin")]
        public string TIN { get; set; }
    }
}
