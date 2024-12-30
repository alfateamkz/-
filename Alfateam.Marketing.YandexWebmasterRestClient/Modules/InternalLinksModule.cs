using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.InternalLinks.HostLinksInternalHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.InternalLinks.HostLinksInternalSamples;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Recrawl.HostRecrawlPost;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class InternalLinksModule : AbsModule
    {
        public InternalLinksModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<HostLinksInternalSamplesResponse> HostLinksInternalSamples(string hostId, HostLinksInternalSamplesQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/links/internal/broken/samples", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostLinksInternalSamplesResponse>(url, Method.Get);
        }

        public async Task<HostLinksInternalHistoryResponse> HostLinksInternalHistory(string hostId, HostLinksInternalHistoryQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/links/internal/broken/history", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostLinksInternalHistoryResponse>(url, Method.Get);
        }
    }
}
