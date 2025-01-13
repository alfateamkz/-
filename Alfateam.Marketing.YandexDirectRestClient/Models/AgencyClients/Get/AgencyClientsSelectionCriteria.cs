using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Get
{
    public class AgencyClientsSelectionCriteria
    {
        [JsonProperty("Logins")]
        public List<string> Logins { get; set; } = new List<string>();

        [JsonProperty("Archived")]
        public YesNoEnum Archived { get; set; }
    }
}
