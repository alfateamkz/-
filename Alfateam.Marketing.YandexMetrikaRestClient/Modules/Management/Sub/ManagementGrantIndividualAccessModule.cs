using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants.GetGrants;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Grants.Individual.DeleteGrant;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management.Sub
{
    public class ManagementGrantIndividualAccessModule : AbsModule
    {
        public ManagementGrantIndividualAccessModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithCounterGrantEResponse> AddGrant(int counterId, WithCounterGrantEBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/grants");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithCounterGrantEResponse>(url, Method.Post, body);
        }

        public async Task<WithCounterGrantEResponse> EditGrant(int counterId, WithCounterGrantEBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/grant");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithCounterGrantEResponse>(url, Method.Put, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteGrant(int counterId, DeleteGrantQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/grant", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }
    }
}
