using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.Management;
using Alfateam.Marketing.AppsFlyerRestClient.Enums;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Management.AppManagementAPIV2;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppListAPIForAdNetworks.AppList.GetAppList;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppManagementAPIV2.AppManagement.AddApp;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppManagementAPIV2.AppManagement.DeleteApp;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppManagementAPIV2.AppManagement.UpdateApp;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Management
{
    public class AppManagementAPIV2 : AbsAPI
    {
        public AppManagementAPIV2(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<AddAppResponse> AddApp(AddAppBody body)
        {
            string url = this.Client.CombineURL($"/app/v2.0/apps/");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<AddAppResponse>(url, Method.Post, body);
        }

        public async Task<UpdateAppResponse> UpdateApp(string appId, AddAppBodyPlatform platform, UpdateAppBody body)
        {
            string url = this.Client.CombineURL($"/app/v2.0/apps/{appId}/{JsonConvert.SerializeObject(platform)}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UpdateAppResponse>(url, Method.Put, body);
        }

        public async Task<DeleteAppResponse> DeleteApp(string appId, DeleteAppPlatform platform)
        {
            string url = this.Client.CombineURL($"/app/v2.0/apps/{appId}/{JsonConvert.SerializeObject(platform)}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DeleteAppResponse>(url, Method.Delete);
        }
    }
}
