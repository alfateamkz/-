using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.Master.MasterReport.GetMasterReport;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.RawDataReport.RawDataPull
{
    public class RawProtect360FraudModule : AbsModule
    {
        public RawProtect360FraudModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> Installs(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/blocked_installs_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> PostAttributionInstalls(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/detection/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> InAppEvents(string appId, RawDataPullGeneralEventsQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/blocked_in_app_events_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> PostAttributionInAppEvents(string appId, RawDataPullGeneralEventsQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/fraud-post-inapps/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> Clicks(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/blocked_clicks_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> BlockedInstallPostbacks(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/blocked_install_postbacks/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
