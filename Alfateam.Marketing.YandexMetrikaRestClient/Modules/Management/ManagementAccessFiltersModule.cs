using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.AccessFilters;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.AccessFilters.DeleteAccessFilter;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.AccessFilters.GetAccessFiltersForCounter;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.GetCounter;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementAccessFiltersModule : AbsModule
    {
        public ManagementAccessFiltersModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithAccessFilterResponse> GetAccessFilter(int counterId, int accessFilterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/access_filter/{accessFilterId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithAccessFilterResponse>(url, Method.Get);
        }

        public async Task<GetAccessFiltersForCounterResponse> GetAccessFiltersForCounter(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/access_filters");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetAccessFiltersForCounterResponse>(url, Method.Get);
        }

        public async Task<WithAccessFilterResponse> CreateAccessFilter(int counterId, WithAccessFilterBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/access_filters");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithAccessFilterResponse>(url, Method.Post, body);
        }

        public async Task<WithAccessFilterResponse> UpdateAccessFilter(int counterId, int accessFilterId, WithAccessFilterBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/access_filter/{accessFilterId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithAccessFilterResponse>(url, Method.Put, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteAccessFilter(int counterId, int accessFilterId, DeleteAccessFilterQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/access_filter/{accessFilterId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }
    }
}
