using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.GetHostById;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Hosts.GetHostSites;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Hosts.HostsAddSite;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class HostsModule : AbsModule
    {
        public HostsModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<GetHostSitesResponse> Hosts()
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetHostSitesResponse>(url, Method.Get);
        }

        public async Task<HostsAddSiteResponse> HostsAddSite(HostsAddSiteBody body)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostsAddSiteResponse>(url, Method.Post, body);
        }

        public async Task HostsDelete(int hostId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}");
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Delete, 204);
        }
    }
}
