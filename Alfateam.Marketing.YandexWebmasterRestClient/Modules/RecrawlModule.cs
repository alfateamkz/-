using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsIndexingInsearchHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Recrawl;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Recrawl.HostRecrawlGet;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Recrawl.HostRecrawlPost;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Recrawl.HostRecrawlQuotaGet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class RecrawlModule : AbsModule
    {
        public RecrawlModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<HostRecrawlPostResponse> HostRecrawlPost(string hostId, HostRecrawlPostBody body)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/recrawl/queue");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostRecrawlPostResponse>(url, Method.Post, body);
        }

        public async Task<HostRecrawlTask> HostRecrawlTaskGet(string hostId, string taskId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/recrawl/queue/{taskId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostRecrawlTask>(url, Method.Get);
        }

        public async Task<HostRecrawlGetResponse> HostRecrawlGet(string hostId, HostRecrawlGetQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/recrawl/queue", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostRecrawlGetResponse>(url, Method.Get);
        }

        public async Task<HostRecrawlQuotaGetResponse> HostRecrawlQuotaGet(string hostId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/recrawl/quota");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostRecrawlQuotaGetResponse>(url, Method.Get);
        }
    }
}
