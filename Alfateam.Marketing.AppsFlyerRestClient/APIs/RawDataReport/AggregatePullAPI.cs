using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.AggregatePull.Aggregate;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.EventTypes.RetrievePerAttributingEntity;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.RawDataReport
{
    public class AggregatePullAPI : AbsAPI
    {
        public AggregatePullAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> Partners(string appId, AggregateGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/agg-data/export/app/{appId}/partners_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> PartnersDaily(string appId, AggregateGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/agg-data/export/app/{appId}/partners_by_date_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> Daily(string appId, AggregateGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/agg-data/export/app/{appId}/daily_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> Geo(string appId, AggregateGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/agg-data/export/app/{appId}/geo_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<string> GeoDaily(string appId, AggregateGeneralQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/agg-data/export/app/{appId}/geo_by_date_report/v5", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
