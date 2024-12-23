﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.EditCounter
{
    public class EditCounterResponse
    {
        [JsonProperty("counter")]
        public CounterFull Counter { get; set; }
    }
}
