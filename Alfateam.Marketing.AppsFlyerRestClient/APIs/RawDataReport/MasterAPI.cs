using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.Master.MasterReport.GetMasterReport;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.MasterFreshness.FreshnessReport.GetLastUpdate;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.RawDataReport
{
    public class MasterAPI : AbsAPI
    {
        public MasterAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetMasterReportResponse> GetMasterReport(IEnumerable<string> appIds,GetMasterReportQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/master-agg-data/v4/app/{string.Join(',', appIds)}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetMasterReportResponse>(url, Method.Get);
        }
    }
}
