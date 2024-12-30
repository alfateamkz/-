using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.ExternalLinks.HostLinksExternalHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.ExternalLinks.HostLinksExternalSamples;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.InternalLinks.HostLinksInternalSamples;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class ExternalLinksModule : AbsModule
    {
        public ExternalLinksModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<HostLinksExternalSamplesResponse> HostLinksExternalSamples(string hostId, HostLinksExternalSamplesQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/links/external/samples", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostLinksExternalSamplesResponse>(url, Method.Get);
        }

        public async Task<HostLinksExternalHistoryResponse> HostLinksExternalHistory(string hostId, HostLinksExternalHistoryQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/links/external/history", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostLinksExternalHistoryResponse>(url, Method.Get);
        }
    }
}
