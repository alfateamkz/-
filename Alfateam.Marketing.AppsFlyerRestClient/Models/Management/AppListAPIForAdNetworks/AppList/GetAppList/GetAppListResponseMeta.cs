﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppListAPIForAdNetworks.AppList.GetAppList
{
    public class GetAppListResponseMeta
    {
        [JsonProperty("total_items")]
        public int TotalItems { get; set; }
    }
}
