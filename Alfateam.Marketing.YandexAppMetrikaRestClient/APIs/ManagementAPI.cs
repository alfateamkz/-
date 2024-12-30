using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Enums.Management;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.CreateApplication;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.GetApplication;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.GetApplicationsList;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.GetCategories;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.UpdateApplication;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Modules.Management;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.APIs
{
    public class ManagementAPI : AbsAPI
    {
        public ManagementAPI(YandexAppMetrikaClient client) : base(client)
        {
            Access = new ManagementAccessModule(this.Client);
            Fingerprints = new ManagementFingerprintsModule(this.Client);
        }

        public ManagementAccessModule Access { get; private set; }
        public ManagementFingerprintsModule Fingerprints { get; private set; }


        public async Task<GetApplicationResponse> GetApplication(int applicationId)
        {
            string url = this.Client.CombineURL($"/management/v1/application/{applicationId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetApplicationResponse>(url, Method.Get);
        }

        public async Task<GetApplicationsListResponse> GetApplicationsList()
        {
            string url = this.Client.CombineURL($"/management/v1/applications");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetApplicationsListResponse>(url, Method.Get);
        }

        public async Task<GetCategoriesResponse> GetCategories(ManagementLocale lang)
        {
            string url = this.Client.CombineURL($"/management/v1/application/categories?lang={JsonConvert.SerializeObject(lang)}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetCategoriesResponse>(url, Method.Get);
        }

        public async Task<CreateApplicationResponse> CreateApplication(CreateApplicationBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/applications");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CreateApplicationResponse>(url, Method.Post, body);
        }

        public async Task<UpdateApplicationResponse> UpdateApplication(int applicationId,UpdateApplicationBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/application/{applicationId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UpdateApplicationResponse>(url, Method.Put, body);
        }

        public async Task DeleteApplication(int applicationId)
        {
            string url = this.Client.CombineURL($"/management/v1/application/{applicationId}");
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Delete, expectedStatusCode: 200);
        }
    }
}
