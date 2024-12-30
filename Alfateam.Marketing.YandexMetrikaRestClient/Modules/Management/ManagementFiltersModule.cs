using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals.GetGoal;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters.GetFilter;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters.GetFilters;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementFiltersModule : AbsModule
    {
        public ManagementFiltersModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithFilterEResponse> GetFilter(int counterId, long filterId, GetFilterQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/filter/{filterId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithFilterEResponse>(url, Method.Get);
        }

        public async Task<GetFiltersResponse> GetFilters(int counterId, GetFiltersQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/filters", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetFiltersResponse>(url, Method.Get);
        }

        public async Task<WithFilterEResponse> EditFilter(int counterId, long filterId, WithFilterEBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/filter/{filterId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithFilterEResponse>(url, Method.Put, body);
        }

        public async Task<WithFilterEResponse> CreateFilter(int counterId, WithFilterEBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/filters");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithFilterEResponse>(url, Method.Post, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteFilter(int counterId, long filterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/filter/{filterId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }
    }
}
