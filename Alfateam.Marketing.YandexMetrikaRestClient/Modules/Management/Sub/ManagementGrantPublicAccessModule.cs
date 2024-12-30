using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants.GetGrants;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management.Sub
{
    public class ManagementGrantPublicAccessModule : AbsModule
    {
        public ManagementGrantPublicAccessModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithCounterGrantEResponse> AddPublicGrant(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/public_grant");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithCounterGrantEResponse>(url, Method.Post);
        }

        public async Task<ManagementGeneralDeleteResponse> DeletePublicGrant(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/deletePublicGrant");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }
    }
}
