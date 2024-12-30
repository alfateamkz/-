using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppListAPIForAdNetworks.AppList.GetAppList;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.CreateBulkUsers;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.GetUsers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.Management.UserManagement
{
    public class UserManagementBulkModule : AbsModule
    {
        public UserManagementBulkModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<CreateBulkUsersResponse> CreateBulkUsers(IEnumerable<CreateBulkUsersBodyUser> users)
        {
            string url = this.Client.CombineURL($"/user-management/v1.0/users");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CreateBulkUsersResponse>(url, Method.Post, users);
        }

        public async Task<GetUsersResponse> GetUsers()
        {
            string url = this.Client.CombineURL($"/user-management/v1.0/users");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetUsersResponse>(url, Method.Get);
        }

        public async Task DeleteUsers(IEnumerable<int> ids)
        {
            string url = this.Client.CombineURL($"/user-management/v1.0/users/{string.Join(",", ids)}");
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Delete, expectedStatusCode: 204);
        }
    }
}
