using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Marketplace;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppListAPIForAdNetworks.AppList.GetAppList;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.UniquePartnerIntegrationParameters;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Management
{
    public class AppListAPIForAdNetworks : AbsAPI
    {
        public AppListAPIForAdNetworks(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetAppListResponse> GetAppList(GetAppListQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/mng/apps", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetAppListResponse>(url, Method.Get);
        }
    }
}
