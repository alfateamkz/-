using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.TestConsole.AllowedDevices.AddDevice;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.TestConsole.Events.RetrieveEvents;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.Mobile.TestConsole
{
    public class MobileTestConsoleEventsModule : AbsModule
    {
        public MobileTestConsoleEventsModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<RetrieveEventsResponse> RetrieveEvents(string appId, RetrieveEventsQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/test-console/v1.0/app/{appId}/events", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<RetrieveEventsResponse>(url, Method.Get);
        }
    }
}
