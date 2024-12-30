using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions.UploadConversions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Conversions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.UserParams.FindUserParamsById;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.UserParams.UploadUserParams;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.UserParams.ConfirmUserParams;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.UserParams.FindAllUserParams;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport
{
    public class DataImportUserParamsModule : AbsModule
    {
        public DataImportUserParamsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<FindUserParamsByIdResponse> FindUserParamsById(int counterId, int uploadingId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/user_params/uploading/{uploadingId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FindUserParamsByIdResponse>(url, Method.Get);
        }

        public async Task<UploadUserParamsResponse> UploadUserParams(int counterId, UploadUserParamsQueryParams queryParams, UploadUserParamsBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/user_params/uploadings/upload", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UploadUserParamsResponse>(url, Method.Post, body);
        }

        public async Task<ConfirmUserParamsResponse> ConfirmUserParams(int counterId, int uploadingId, ConfirmUserParamsBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/user_params/uploading/{uploadingId}/confirm");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ConfirmUserParamsResponse>(url, Method.Post, body);
        }

        public async Task<FindAllUserParamsResponse> FindAllUserParams(int counterId, FindAllUserParamsQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/user_params/uploadings", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FindAllUserParamsResponse>(url, Method.Get);
        }
    }
}
