using Alfateam.Marketing.AppsFlyerRestClient.Enums.Management.AppListAPIForAdNetworks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppListAPIForAdNetworks.AppList.GetAppList
{
    public class GetAppListQueryParams
    {
        [JsonProperty("capabilities")]
        public GetAppListQueryParamsCapabilitiesType Capabilities { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}
