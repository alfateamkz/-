﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Models.Feeds.Get
{
    public class FileFeedGet
    {
        [JsonProperty("Filename")]
        public string Filename { get; set; }
    }
}
