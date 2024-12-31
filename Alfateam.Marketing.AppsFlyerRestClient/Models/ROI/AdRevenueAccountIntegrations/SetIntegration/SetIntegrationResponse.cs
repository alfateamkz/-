﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.SetIntegration
{
    public class SetIntegrationResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}