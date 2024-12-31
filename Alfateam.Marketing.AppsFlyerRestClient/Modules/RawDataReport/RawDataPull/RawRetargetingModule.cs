using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull.Retargeting.Conversions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull.Retargeting.InAppEvents;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.RawDataReport.RawDataPull
{
    public class RawRetargetingModule : AbsModule
    {
        public RawRetargetingModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> GetConversion(string appId, GetConversionQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/installs-retarget/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> GetInAppEvents(string appId, GetInAppEventsQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/in-app-events-retarget/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
