using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Accounts.GetAccounts;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Delegates.AddDelegate;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Delegates.GetDelegates;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementDelegatesModule : AbsModule
    {
        public ManagementDelegatesModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<GetDelegatesResponse> GetDelegates(GetDelegatesQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/delegates", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetDelegatesResponse>(url, Method.Get);
        }

        public async Task<AddDelegateResponse> AddDelegate(AddDelegateBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/delegates");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<AddDelegateResponse>(url, Method.Post, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteDelegate(string userLogin)
        {
            string url = this.Client.CombineURL($"/management/v1/delegate?user_login={userLogin}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }
    }
}
