using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantArchiveAllPages;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantURLs;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdImportantURLsHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostIdSummary;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostsIndexingHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostsIndexingSamples;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps.HostSitemapsGet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class IndexingModule : AbsModule
    {
        public IndexingModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<HostIdSummaryResponse> HostIdSummary(string hostId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/summary");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostIdSummaryResponse>(url, Method.Get);
        }

        public async Task<HostsIndexingHistoryResponse> HostsIndexingHistory(string hostId, HostsIndexingHistoryQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/indexing/history", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostsIndexingHistoryResponse>(url, Method.Get);
        }

        public async Task<HostsIndexingSamplesResponse> HostsIndexingHistory(string hostId, HostsIndexingSamplesQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/indexing/samples", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostsIndexingSamplesResponse>(url, Method.Get);
        }

        public async Task<HostIdImportantURLsResponse> HostIdImportantURLs(string hostId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/important-urls");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostIdImportantURLsResponse>(url, Method.Get);
        }

        public async Task<HostIdImportantURLsHistoryResponse> HostIdImportantURLsHistory(string hostId, string urlParam)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/important-urls/history?url={urlParam}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostIdImportantURLsHistoryResponse>(url, Method.Get);
        }

        public async Task<HostIdImportantArchiveAllPagesGetResponse> HostIdImportantArchiveAllPagesGet(string hostId, string taskId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/indexing/archive/{taskId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostIdImportantArchiveAllPagesGetResponse>(url, Method.Get);
        }

        public async Task<HostIdImportantArchiveAllPagesPostResponse> HostIdImportantArchiveAllPagesPost(string hostId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/indexing/archive");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostIdImportantArchiveAllPagesPostResponse>(url, Method.Post);
        }
    }
}
