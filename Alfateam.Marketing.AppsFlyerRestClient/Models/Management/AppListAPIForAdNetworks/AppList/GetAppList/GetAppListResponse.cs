using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppListAPIForAdNetworks.AppList.GetAppList
{
    public class GetAppListResponse
    {
        [Description("data")]
        public List<GetAppListResponseObject> Data { get; set; } = new List<GetAppListResponseObject>();

        [Description("meta")]
        public GetAppListResponseMeta Meta { get; set; }

        [Description("links")]
        public GetAppListResponseLinks Links { get; set; }
    }
}
