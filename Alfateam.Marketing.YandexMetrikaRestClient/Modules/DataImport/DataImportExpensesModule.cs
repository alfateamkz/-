using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.FindAllExpenses;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.UploadMultipart;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.UploadRemoveBody;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Expenses.UploadRemoveSingleLine;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Delegates.GetDelegates;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport
{
    public class DataImportExpensesModule : AbsModule
    {
        public DataImportExpensesModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithExpenseUploadingResponse> UploadMultipart(int counterId, UploadMultipartQueryParams queryParams, UploadMultipartBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/expense/upload", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithExpenseUploadingResponse>(url, Method.Post, body);
        }

        public async Task<WithExpenseUploadingResponse> UploadRemoveSingleLine(int counterId, UploadRemoveSingleLineQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/expense/delete_single", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithExpenseUploadingResponse>(url, Method.Post);
        }

        public async Task<WithExpenseUploadingResponse> UploadRemoveBody(int counterId, UploadRemoveBodyQueryParams queryParams, UploadRemoveBodyBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/expense/delete_single", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithExpenseUploadingResponse>(url, Method.Post, body);
        }

        public async Task<FindAllExpensesResponse> FindAllExpenses(int counterId, FindAllExpensesQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/expense/uploadings", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FindAllExpensesResponse>(url, Method.Get);
        }

        public async Task<WithExpenseUploadingResponse> FindExpenseById(int counterId, int uploadingId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/expense/uploading/{uploadingId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithExpenseUploadingResponse>(url, Method.Get);
        }
    }
}
