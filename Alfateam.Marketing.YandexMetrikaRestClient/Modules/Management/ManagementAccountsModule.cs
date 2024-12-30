using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Accounts.GetAccounts;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Accounts.UpdateAccounts;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Segments;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementAccountsModule : AbsModule
    {
        public ManagementAccountsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<GetAccountsResponse> GetAccounts(GetAccountsQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/accounts", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetAccountsResponse>(url, Method.Get);
        }

        public async Task<UpdateAccountsResponse> UpdateAccounts(UpdateAccountsBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/accounts");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UpdateAccountsResponse>(url, Method.Put, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteAccount(string userLogin)
        {
            string url = this.Client.CombineURL($"/management/v1/account?user_login={userLogin}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }
    }
}
