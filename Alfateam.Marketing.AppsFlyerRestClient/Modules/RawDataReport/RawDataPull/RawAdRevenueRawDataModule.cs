using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull.AdRevenueRawData.RetargetingAdRevenue;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull.Retargeting.Conversions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.RawDataReport.RawDataPull
{
    public class RawAdRevenueRawDataModule : AbsModule
    {
        public RawAdRevenueRawDataModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> GetAttributedAdRevenue(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/ad_revenue_raw/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> GetOrganicAdRevenue(string appId, RawDataPullGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/ad_revenue_organic_raw/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> GetRetargetingAdRevenue(string appId, GetRetargetingAdRevenueQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/raw-data/export/app/{appId}/ad-revenue-raw-retarget/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
