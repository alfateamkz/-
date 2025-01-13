using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Alfateam.Marketing.YandexDirectRestClient.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Update
{
    public class ClientSettingUpdateItem
    {
        [JsonProperty("Option")]
        public ClientSettingAddEnum Option { get; set; }

        [JsonProperty("Value")]
        public YesNoEnum Value { get; set; }
    }
}
