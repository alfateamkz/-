using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANAggregatedPerformanceReport.PerformanceReport;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANAggregatedPostbackByArrivalDate.Postbacks;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.SKAN
{
    public class SKANAggregatedPerformanceReportAPI : AbsAPI
    {
        public SKANAggregatedPerformanceReportAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> GetPerformanceReport(string appId, GetPerformanceReportQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/skadnetworks/v3/data/app/{appId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
