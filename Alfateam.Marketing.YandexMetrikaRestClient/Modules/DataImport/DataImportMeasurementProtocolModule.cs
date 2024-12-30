using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.MeasurementProtocol.DeleteToken;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.MeasurementProtocol.GenerateToken;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.UserParams.FindUserParamsById;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport
{
    public class DataImportMeasurementProtocolModule : AbsModule
    {
        public DataImportMeasurementProtocolModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<GenerateTokenResponse> GenerateToken(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/measurement/generate");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GenerateTokenResponse>(url, Method.Get);
        }

        public async Task<DeleteTokenResponse> DeleteToken(int counterId, DeleteTokenQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/measurement/delete", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DeleteTokenResponse>(url, Method.Post);
        }
    }
}
