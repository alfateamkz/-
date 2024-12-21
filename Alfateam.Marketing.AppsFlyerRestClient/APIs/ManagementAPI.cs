using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Management;
using Alfateam.Marketing.AppsFlyerRestClient.APIs.Measurements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs
{
    public class ManagementAPI : AbsAPI
    {
        public ManagementAPI(AppsFlyerClient client) : base(client)
        {
            AppListAPIForAdNetworks = new AppListAPIForAdNetworks(this.Client);
            AppManagementAPIV2 = new AppManagementAPIV2(this.Client);
            UserManagementAPI = new UserManagementAPI(this.Client);
        }

        public AppListAPIForAdNetworks AppListAPIForAdNetworks { get; private set; }
        public AppManagementAPIV2 AppManagementAPIV2 { get; private set; }
        public UserManagementAPI UserManagementAPI { get; private set; }
    }
}
