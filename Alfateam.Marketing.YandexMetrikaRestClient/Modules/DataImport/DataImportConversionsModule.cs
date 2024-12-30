using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls.UploadCalls;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions.FindAllConversions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions.UploadConversions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport
{
    public class DataImportConversionsModule : AbsModule
    {
        public DataImportConversionsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithOfflineConversionUploadingResponse> UploadConversions(int counterId, UploadConversionsQueryParams queryParams, UploadConversionsBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/offline_conversions/upload", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithOfflineConversionUploadingResponse>(url, Method.Post, body);
        }

        public async Task<FindAllConversionsResponse> FindAllConversions(int counterId, FindAllConversionsQueryParameters queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/offline_conversions/uploadings", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FindAllConversionsResponse>(url, Method.Get);
        }

        public async Task<WithOfflineConversionUploadingResponse> FindConversionUploadingById(int counterId, int uploadingId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/offline_conversions/uploading/{uploadingId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithOfflineConversionUploadingResponse>(url, Method.Get);
        }
    }
}
