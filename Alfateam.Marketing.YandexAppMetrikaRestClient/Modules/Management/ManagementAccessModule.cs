using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.AddAccess;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.EditAccess;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.ListEvents;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.Access.ListPartners;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.GetApplication;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.Modules.Management
{
    public class ManagementAccessModule : AbsModule
    {
        public ManagementAccessModule(YandexAppMetrikaClient client) : base(client)
        {
        }

        public async Task<WithGrantResponse> AddAccess(int applicationId, AddAccessBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/application/{applicationId}/grants");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithGrantResponse>(url, Method.Post, body);
        }

        public async Task<WithGrantResponse> EditAccess(int applicationId, EditAccessBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/application/{applicationId}/grant");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithGrantResponse>(url, Method.Put, body);
        }

        public async Task<ListPartnersResponse> ListPartners()
        {
            string url = this.Client.CombineURL($"/management/v1/tracking/partners");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ListPartnersResponse>(url, Method.Get);
        }

        public async Task<ListEventsResponse> ListEvents(int applicationId)
        {
            string url = this.Client.CombineURL($"/v1/traffic/sources/events?appId={applicationId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ListEventsResponse>(url, Method.Get);
        }

        public async Task DeleteAccess(int applicationId, string userLogin)
        {
            string url = this.Client.CombineURL($"/management/v1/application/{applicationId}/grant?user_login={userLogin}");
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Delete, expectedStatusCode: 200);
        }
    }
}
