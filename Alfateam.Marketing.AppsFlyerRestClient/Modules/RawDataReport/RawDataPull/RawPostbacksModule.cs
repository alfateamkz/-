using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull;
using Microsoft.VisualBasic;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.RawDataReport.RawDataPull
{
    public class RawPostbacksModule : AbsModule
    {
        public RawPostbacksModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> InstallPostbacks(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/postbacks/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> InAppEventPostbacks(string appId, RawDataPullGeneralEventsQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/in-app-events-postbacks/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> RetargetingInAppEventPostbacks(string appId, RawDataPullGeneralEventsQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/retarget_in_app_events_postbacks/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> RetargetingConversionsPostbacks(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/retarget_install_postbacks/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
