﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management
{
    public class ManagementGeneralDeleteResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
