using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.MasterFreshness.FreshnessReport.GetLastUpdate;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.TrueRevenueTax.GetTaxesList;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.RawDataReport
{
    public class MasterFreshnessAPI : AbsAPI
    {
        public MasterFreshnessAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetLastUpdateResponse> GetLastUpdate()
        {
            string url = "https://hq1.appsflyer.com/api/master-agg-data/lastupdate";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetLastUpdateResponse>(url, Method.Get);
        }
    }
}
