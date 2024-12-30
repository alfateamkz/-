using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Contacts.UploadContacts;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Contacts.UploadContactsCSV;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Contacts.UploadContactsJSON;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.GetOrderStatuses;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.MapOrderStatuses;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Orders.UploadOrdersCSV;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.Orders.UploadOrdersJSON;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.CreateAttributes;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.CreateProducts;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.GetAttributes;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.GetPredefinedTypes;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.GetTypes;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Simple.UploadSimpleOrders;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.DataImport.Sub
{
    public class DataImportFromCRMDetailedModule : AbsModule
    {
        public DataImportFromCRMDetailedModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<MapOrderStatusesResponse> MapOrderStatuses(int counterId, MapOrderStatusesBody body)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/schema/order_statuses");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<MapOrderStatusesResponse>(url, Method.Post, body);
        }

        public async Task<GetOrderStatusesResponse> MapOrderStatuses(int counterId)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/schema/order_statuses");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetOrderStatusesResponse>(url, Method.Get);
        }

        public async Task<UploadContactsCSVResponse> UploadContactsCSV(int counterId, UploadContactsCSVQueryParams queryParams, UploadContactsCSVBody body)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/data/contacts/csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UploadContactsCSVResponse>(url, Method.Post, body);
        }

        public async Task<UploadContactsJSONResponse> UploadContactsJSON(int counterId, UploadContactsJSONQueryParams queryParams, UploadContactsJSONBody body)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/data/contacts/json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UploadContactsJSONResponse>(url, Method.Post, body);
        }

        public async Task<UploadOrdersCSVResponse> UploadOrdersCSV(int counterId, UploadOrdersCSVQueryParams queryParams, UploadOrdersCSVBody body)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/data/orders/csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UploadOrdersCSVResponse>(url, Method.Post, body);
        }

        public async Task<UploadOrdersJSONResponse> UploadOrdersJSON(int counterId, UploadOrdersJSONQueryParams queryParams, UploadOrdersJSONBody body)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/data/orders/json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UploadOrdersJSONResponse>(url, Method.Post, body);
        }






        public async Task<CreateAttributesResponse> CreateAttributes(int counterId, CreateAttributesQueryParams queryParams, CreateAttributesBody body)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/schema/attributes", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CreateAttributesResponse>(url, Method.Post, body);
        }

        public async Task<CreateProductsResponse> CreateProducts(int counterId, CreateProductsBody body)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/schema/products");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CreateProductsResponse>(url, Method.Post, body);
        }

        public async Task<GetAttributesResponse> GetAttributes(int counterId, GetAttributesQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/schema/attributes", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetAttributesResponse>(url, Method.Get);
        }

        public async Task<GetPredefinedTypesResponse> GetPredefinedTypes(int counterId)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/schema/predefined_types");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetPredefinedTypesResponse>(url, Method.Get);
        }

        public async Task<GetTypesResponse> GetTypes(int counterId)
        {
            string url = this.Client.CombineURL($"/cdp/api/v1/counter/{counterId}/schema/types");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetTypesResponse>(url, Method.Get);
        }
    }
}
