using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingRoles.GetRoles;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.GetUsers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.Management.UserManagement
{
    public class UserManagementRolesModule : AbsModule
    {
        public UserManagementRolesModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetRolesResponse> GetRoles()
        {
            string url = this.Client.CombineURL($"/user-management/v1.0/roles");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetRolesResponse>(url, Method.Get);
        }
    }
}
