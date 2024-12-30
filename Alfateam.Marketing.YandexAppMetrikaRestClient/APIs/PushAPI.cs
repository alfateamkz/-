using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Post.PostImportEvents;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.GetGroups;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.GetStatusGroupId;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.GetStatusId;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostGroups;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PostSendBatch;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Push.PutGroupId;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.APIs
{
    public class PushAPI : AbsAPI
    {
        public PushAPI(YandexAppMetrikaClient client) : base(client)
        {
        }

        public async Task<WithPushGroupResponse> PostGroups(PostGroupsBody body)
        {
            string url = this.Client.CombineURL($"/push/v1/management/groups");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithPushGroupResponse>(url, Method.Post, body);
        }

        public async Task<WithPushGroupResponse> GetGroups(string appId)
        {
            string url = this.Client.CombineURL($"/push/v1/management/groups?appId={appId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithPushGroupResponse>(url, Method.Get);
        }

        public async Task<WithPushGroupResponse> PutGroupId(string groupId, PutGroupIdBody body)
        {
            string url = this.Client.CombineURL($"/push/v1/management/group/{groupId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithPushGroupResponse>(url, Method.Put, body);
        }

        public async Task DeleteGroupId(string groupId)
        {
            string url = this.Client.CombineURL($"/push/v1/management/group/{groupId}");
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Delete, expectedStatusCode: 200);
        }

        public async Task RestoreGroupId(string groupId)
        {
            string url = this.Client.CombineURL($"/push/v1/management/group/{groupId}/restore");
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Post, expectedStatusCode: 200);
        }

        public async Task<PostSendBatchResponse> PostSendBatch(PostSendBatchBody body)
        {
            string url = this.Client.CombineURL($"/push/v1/send-batch");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<PostSendBatchResponse>(url, Method.Post, body);
        }

        public async Task<GetStatusIdResponse> GetStatusId(string transferId)
        {
            string url = this.Client.CombineURL($"/push/v1/status/{transferId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetStatusIdResponse>(url, Method.Get);
        }

        public async Task<GetStatusGroupIdResponse> GetStatusGroupId(string groupId, string clientTransferId)
        {
            string url = this.Client.CombineURL($"/push/v1/status/{groupId}/{clientTransferId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetStatusGroupIdResponse>(url, Method.Get);
        }
    }
}
