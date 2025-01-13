﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models
{
    public class ResultModel<T>
    {
        [JsonProperty("result")]
        public T Result { get; set; } 
    }
}
