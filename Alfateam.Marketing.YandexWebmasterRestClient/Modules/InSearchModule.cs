using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Indexing.HostsIndexingHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsIndexingInsearchHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsIndexingInSearchSamples;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsSearchEventsHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.InSearch.HostsSearchEventsSamples;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class InSearchModule : AbsModule
    {
        public InSearchModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<HostsIndexingInsearchHistoryResponse> HostsIndexingInsearchHistory(string hostId, HostsIndexingInsearchHistoryQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/search-urls/in-search/history", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostsIndexingInsearchHistoryResponse>(url, Method.Get);
        }

        public async Task<HostsIndexingInSearchSamplesResponse> HostsIndexingInSearchSamples(string hostId, HostsIndexingInSearchSamplesQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/search-urls/in-search/samples", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostsIndexingInSearchSamplesResponse>(url, Method.Get);
        }

        public async Task<HostsSearchEventsHistoryResponse> HostsSearchEventsHistory(string hostId, HostsSearchEventsHistoryQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/search-urls/events/history", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostsSearchEventsHistoryResponse>(url, Method.Get);
        }

        public async Task<HostsSearchEventsSamplesResponse> HostsSearchEventsSamples(string hostId, HostsSearchEventsSamplesQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/search-urls/events/samples", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostsSearchEventsSamplesResponse>(url, Method.Get);
        }
    }
}
