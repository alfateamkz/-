using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.HostSearchQueries.HostSearchQueriesPopular;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps.HostSitemapsGet;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps.HostUserAddedSitemapsGet;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Sitemaps.HostUserAddedSitemapsPost;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class SitemapsModule : AbsModule
    {
        public SitemapsModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<HostSitemapsGetResponse> HostSitemapsGet(string hostId, HostSitemapsGetQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/sitemaps", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostSitemapsGetResponse>(url, Method.Get);
        }

        public async Task<Sitemap> HostSitemapsSitemapIdGet(string hostId, int sitemapId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/sitemaps/{sitemapId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<Sitemap>(url, Method.Get);
        }

        public async Task<HostUserAddedSitemapsGetResponse> HostUserAddedSitemapsGet(string hostId, HostUserAddedSitemapsGetQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/user-added-sitemaps", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostUserAddedSitemapsGetResponse>(url, Method.Get);
        }

        public async Task<UserSitemap> HostUserAddedSitemapsSitemapIdGet(string hostId, int sitemapId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/user-added-sitemaps/{sitemapId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UserSitemap>(url, Method.Get);
        }

        public async Task<HostUserAddedSitemapsPostResponse> HostUserAddedSitemapsPost(string hostId, HostUserAddedSitemapsPostBody body)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/user-added-sitemaps");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostUserAddedSitemapsPostResponse>(url, Method.Post, body);
        }

        public async Task HostUserAddedSitemapsSitemapIdDelete(string hostId, int sitemapId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/user-added-sitemaps/{sitemapId}");
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Delete, 204);
        }
    }
}
