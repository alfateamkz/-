using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Labels;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Labels.GetLabels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementLabelsModule : AbsModule
    {
        public ManagementLabelsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithLabelResponse> GetLabel(int labelId)
        {
            string url = this.Client.CombineURL($"/management/v1/label/{labelId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithLabelResponse>(url, Method.Get);
        }

        public async Task<WithLabelResponse> UpdateLabel(int labelId, WithLabelBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/label/{labelId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithLabelResponse>(url, Method.Put, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteLabel(int labelId)
        {
            string url = this.Client.CombineURL($"/management/v1/label/{labelId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }

        public async Task<WithLabelResponse> CreateLabel(WithLabelBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/labels");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithLabelResponse>(url, Method.Post, body);
        }

        public async Task<GetLabelsResponse> GetLabels()
        {
            string url = this.Client.CombineURL($"/management/v1/labels");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetLabelsResponse>(url, Method.Get);
        }
    }
}
