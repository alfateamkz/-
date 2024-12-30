using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.ExternalLinks.HostLinksExternalSamples;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsAddInfo;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsAddStart;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsBatchAdd;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsBatchDelete;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsList;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Feeds.FeedsRegionChange;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class FeedsModule : AbsModule
    {
        public FeedsModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<FeedsAddStartResponse> FeedsAddStart(string hostId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/feeds/add/start");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FeedsAddStartResponse>(url, Method.Post);
        }

        public async Task<FeedsAddInfoResponse> FeedsAddInfo(string hostId, FeedsAddStartQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/feeds/add/info", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FeedsAddInfoResponse>(url, Method.Get);
        }

        public async Task<FeedsBatchAddResponse> FeedsBatchAdd(string hostId, FeedsBatchAddBody body)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/feeds/batch/add");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FeedsBatchAddResponse>(url, Method.Post, body);
        }

        public async Task<FeedsListResponse> FeedsList(string hostId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/feeds/list");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FeedsListResponse>(url, Method.Get);
        }

        public async Task<FeedsBatchDeleteResponse> FeedsBatchRemove(string hostId, FeedsBatchDeleteBody body)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/feeds/batch/remove");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<FeedsBatchDeleteResponse>(url, Method.Delete, body);
        }

        public async Task FeedsRegionChange(string hostId, FeedsRegionChangeBody body)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/feeds/change");
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Post, expectedStatusCode: 200);
        }
    }
}
