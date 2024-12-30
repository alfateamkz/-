using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Labels;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Operations.GetOperations;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementOperationsModule : AbsModule
    {
        public ManagementOperationsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithOperationEResponse> GetOperation(int counterId, int operationId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/operation/{operationId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithOperationEResponse>(url, Method.Get);
        }

        public async Task<WithOperationEResponse> GetOperation(int counterId, int operationId, WithOperationEBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/operation/{operationId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithOperationEResponse>(url, Method.Put, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteOperation(int counterId, int operationId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/operation/{operationId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }

        public async Task<WithOperationEResponse> CreateOperation(int counterId, int operationId, WithOperationEBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/operations");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithOperationEResponse>(url, Method.Post, body);
        }

        public async Task<GetOperationsResponse> GetOperations(int counterId, GetOperationsQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/operations", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetOperationsResponse>(url, Method.Get);
        }
    }
}
