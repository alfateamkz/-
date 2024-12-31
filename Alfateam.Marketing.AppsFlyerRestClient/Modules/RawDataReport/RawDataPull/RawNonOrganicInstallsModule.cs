using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.RawDataReport.RawDataPull
{
    public class RawNonOrganicInstallsModule : AbsModule
    {
        public RawNonOrganicInstallsModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> Installs(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/installs_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> InAppEvents(string appId, RawDataPullGeneralEventsQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/in_app_events_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> Uninstalls(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/uninstall_events_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> Reinstalls(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/reinstalls/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
