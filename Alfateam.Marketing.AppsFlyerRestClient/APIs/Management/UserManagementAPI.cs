using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.AppListAPIForAdNetworks.AppList.GetAppList;
using Alfateam.Marketing.AppsFlyerRestClient.Modules.Management.UserManagement;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Management
{
    public class UserManagementAPI : AbsAPI
    {
        public UserManagementAPI(AppsFlyerClient client) : base(client)
        {
            Bulk = new UserManagementBulkModule(this.Client);
            Roles = new UserManagementRolesModule(this.Client);
        }

        public UserManagementBulkModule Bulk { get; private set; }
        public UserManagementRolesModule Roles { get; private set; }
    }
}
