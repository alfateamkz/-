using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants.GetGrants;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations.GetOperations;
using Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management.Sub;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementGrantsModule : AbsModule
    {
        public ManagementGrantsModule(YandexMetrikaClient client) : base(client)
        {
            PublicAccess = new ManagementGrantPublicAccessModule(this.Client);
            IndividualAccess = new ManagementGrantIndividualAccessModule(this.Client);
        }

        public ManagementGrantPublicAccessModule PublicAccess { get; private set; }
        public ManagementGrantIndividualAccessModule IndividualAccess { get; private set; }


        public async Task<GetGrantsResponse> GetGrants(int counterId, GetGrantsQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/grants", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetGrantsResponse>(url, Method.Get);
        }

        public async Task<WithCounterGrantEResponse> GetGrant(int counterId, string userLogin)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/grant?user_login={userLogin}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithCounterGrantEResponse>(url, Method.Get);
        }

        public async Task<WithCounterGrantEResponse> GetMyGrant(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/my_grant");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithCounterGrantEResponse>(url, Method.Get);
        }
    }
}
