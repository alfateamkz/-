using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.CounterLabels.SetCounterLabel;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.CounterLabels.UnsetCounterLabel;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Delegates.AddDelegate;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementCounterLabelsModule : AbsModule
    {
        public ManagementCounterLabelsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<SetCounterLabelResponse> SetCounterLabel(int counterId, int labelId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/label/{labelId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<SetCounterLabelResponse>(url, Method.Post);
        }

        public async Task<UnsetCounterLabelResponse> UnsetCounterLabel(int counterId, int labelId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/label/{labelId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UnsetCounterLabelResponse>(url, Method.Delete);
        }
    }
}
