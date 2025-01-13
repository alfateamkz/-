﻿using Alfateam.Marketing.YandexDirectRestClient.Enums.AgencyClients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.AgencyClients.Update
{
    public class TinInfoUpdate
    {
        [JsonProperty("TinType")]
        public TinTypeEnum TINType { get; set; }

        [JsonProperty("Tin")]
        public string TIN { get; set; }
    }
}
