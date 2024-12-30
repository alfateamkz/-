using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Clients.GetClients;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Delegates.GetDelegates;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementClientsModule : AbsModule
    {
        public ManagementClientsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<GetClientsResponse> GetClients(GetClientsQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/clients", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetClientsResponse>(url, Method.Get);
        }
    }
}
