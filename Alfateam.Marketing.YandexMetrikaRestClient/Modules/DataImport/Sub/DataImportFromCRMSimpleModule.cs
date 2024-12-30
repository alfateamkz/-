using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.UploadMultipart;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Simple.UploadSimpleOrders;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport.Sub
{
    public class DataImportFromCRMSimpleModule : AbsModule
    {
        public DataImportFromCRMSimpleModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<UploadSimpleOrdersResponse> UploadSimpleOrders(int counterId, UploadSimpleOrdersQueryParams queryParams, UploadSimpleOrdersBody body)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/data/simple_orders", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UploadSimpleOrdersResponse>(url, Method.Post, body);
        }
    }
}
