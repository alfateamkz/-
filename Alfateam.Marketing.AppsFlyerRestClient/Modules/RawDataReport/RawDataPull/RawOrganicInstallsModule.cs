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
    public class RawOrganicInstallsModule : AbsModule
    {
        public RawOrganicInstallsModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> OrganicInstalls(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/organic_installs_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> OrganicInAppEvents(string appId, RawDataPullGeneralEventsQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/organic_in_app_events_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> OrganicUninstalls(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/organic_uninstall_events_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> OrganicReinstalls(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/reinstalls_organic/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
