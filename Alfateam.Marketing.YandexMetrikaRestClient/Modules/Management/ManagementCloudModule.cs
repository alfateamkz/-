using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Clients.GetClients;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Cloud.GetExportsByCounter;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.CounterLabels.UnsetCounterLabel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementCloudModule : AbsModule
    {
        public ManagementCloudModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<GetExportsByCounterResponse> GetExportsByCounter(int counterId)
        {
            string url = this.Client.CombineURL($"/export/v1/cloud/counter/{counterId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetExportsByCounterResponse>(url, Method.Get);
        }

        public async Task<ManagementGeneralDeleteResponse> RemoveCounter(int counterId, int ceId)
        {
            string url = this.Client.CombineURL($"/export/v1/cloud/{ceId}/counter/{counterId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }
    }
}
