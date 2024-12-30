using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.UploadMultipart;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses;
using Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport.Sub;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.GetLastUploadings;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport
{
    public class DataImportImportFromCRMModule : AbsModule
    {
        public DataImportImportFromCRMModule(YandexMetrikaClient client) : base(client)
        {
            Detailed = new DataImportFromCRMDetailedModule(this.Client);
            Simple = new DataImportFromCRMSimpleModule(this.Client); 
        }

        public DataImportFromCRMDetailedModule Detailed { get; private set; }
        public DataImportFromCRMSimpleModule Simple { get; private set; }



        public async Task<GetLastUploadingsResponse> GetLastUploadings(int counterId, GetLastUploadingsQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/last_uploadings", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetLastUploadingsResponse>(url, Method.Get);
        }

    }
}
