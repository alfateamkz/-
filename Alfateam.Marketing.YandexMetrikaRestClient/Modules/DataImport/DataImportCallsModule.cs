using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls.FindAllCallUploadings;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls.FindCallUploadingById;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls.UploadCalls;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.GetLastUploadings;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport
{
    public class DataImportCallsModule : AbsModule
    {
        public DataImportCallsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<UploadCallsResponse> UploadCalls(int counterId, UploadCallsQueryParameters queryParams, UploadCallsBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/offline_conversions/upload_calls", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UploadCallsResponse>(url, Method.Post, body);
        }

        public async Task<FindAllCallUploadingsResponse> FindAllCallUploadings(int counterId, FindAllCallUploadingsQueryParameters queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/offline_conversions/calls_uploadings", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FindAllCallUploadingsResponse>(url, Method.Get);
        }

        public async Task<FindCallUploadingByIdResponse> FindCallUploadingById(int counterId, int uploadingId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/offline_conversions/calls_uploading/{uploadingId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FindCallUploadingByIdResponse>(url, Method.Get);
        }
    }
}
