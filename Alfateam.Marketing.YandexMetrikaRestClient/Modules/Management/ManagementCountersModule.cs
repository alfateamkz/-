using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.AddCounter;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.EditCounter;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.GetCounter;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.GetCounters;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Counters.UndeleteCounter;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Labels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementCountersModule : AbsModule
    {
        public ManagementCountersModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<GetCounterResponse> GetCounter(int counterId, GetCounterQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetCounterResponse>(url, Method.Get);
        }

        public async Task<EditCounterResponse> EditCounter(int counterId, EditCounterQueryParams queryParams, EditCounterBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<EditCounterResponse>(url, Method.Put, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteCounter(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }

        public async Task<GetCountersResponse> GetCounters(GetCountersQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counters", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetCountersResponse>(url, Method.Get);
        }

        public async Task<AddCounterResponse> AddCounter(AddCounterBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counters");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<AddCounterResponse>(url, Method.Post, body);
        }

        public async Task<UndeleteCounterResponse> UndeleteCounter(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/undelete");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UndeleteCounterResponse>(url, Method.Delete);
        }

    }
}
