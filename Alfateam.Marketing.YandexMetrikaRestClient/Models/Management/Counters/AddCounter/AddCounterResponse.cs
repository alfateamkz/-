﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.AddCounter
{
    public class AddCounterResponse
    {
        [JsonProperty("counter")]
        public CounterFull Counter { get; set; }
    }
}
