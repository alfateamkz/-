using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients
{
    public class GrantItem
    {
        [JsonProperty("Privilege")]
        public PrivilegeEnum Privilege { get; set; }

        [JsonProperty("Value")]
        public YesNoEnum Value { get; set; }
    }
}
