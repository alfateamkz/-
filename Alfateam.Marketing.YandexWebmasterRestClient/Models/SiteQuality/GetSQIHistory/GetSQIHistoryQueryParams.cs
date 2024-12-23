﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Models.SiteQuality.GetSQIHistory
{
    public class GetSQIHistoryQueryParams
    {
        [JsonProperty("date_from")]
        public DateTime DateFrom { get; set; }

        [JsonProperty("date_to")]
        public DateTime DateTo { get; set; }
    }
}
