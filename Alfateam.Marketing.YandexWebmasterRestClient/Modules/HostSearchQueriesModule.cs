using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostQueryAnalytics;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostSearchQueriesHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostSearchQueriesHistoryAll;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostSearchQueriesPopular;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.SiteQuality.GetSQIHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.SiteQuality.NewFolder;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class HostSearchQueriesModule : AbsModule
    {
        public HostSearchQueriesModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<HostSearchQueriesPopularResponse> HostSearchQueriesPopular(string hostId, HostSearchQueriesPopularQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/search-queries/popular", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostSearchQueriesPopularResponse>(url, Method.Get);
        }

        public async Task<HostSearchQueriesHistoryAllResponse> HostSearchQueriesHistoryAll(string hostId, HostSearchQueriesHistoryAllQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/search-queries/all/history", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostSearchQueriesHistoryAllResponse>(url, Method.Get);
        }

        public async Task<HostSearchQueriesHistoryResponse> HostSearchQueriesHistory(string hostId, int queryId, HostSearchQueriesHistoryQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/search-queries/{queryId}/history", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostSearchQueriesHistoryResponse>(url, Method.Get);
        }

        public async Task<HostQueryAnalyticsResponse> HostQueryAnalytics(string hostId, HostQueryAnalyticsBody body)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/query-analytics/list");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostQueryAnalyticsResponse>(url, Method.Post, body);
        }
    }
}
