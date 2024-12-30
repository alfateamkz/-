using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Management.GetApplication;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Data;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Drilldown;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.APIs
{
    public class ReportsAPI : AbsAPI
    {
        public ReportsAPI(YandexAppMetrikaClient client) : base(client)
        {
        }

        public async Task<ReportsDataResponse> Data(ReportsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/stat/v1/data", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ReportsDataResponse>(url, Method.Get);
        }

        public async Task<ReportsDrilldownResponse> Drilldown(ReportsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/stat/v1/data/drilldown", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ReportsDrilldownResponse>(url, Method.Get);
        }
    }
}
