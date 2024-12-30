using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.AccessFilters;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ByTime;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Comparison;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.ComparisonDrilldown;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Data;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Drilldown;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Pivot;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.PivotDrilldown;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.APIs
{
    public class StatAPI : AbsAPI
    {
        public StatAPI(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<DataResponse> Data(DataQueryParameters queryParameters)
        {
            string url = this.Client.CombineURL($"/stat/v1/data", queryParameters);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DataResponse>(url, Method.Get);
        }

        public async Task<PivotResponse> Pivot(PivotQueryParams queryParameters)
        {
            string url = this.Client.CombineURL($"/stat/v1/data/pivot", queryParameters);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<PivotResponse>(url, Method.Get);
        }

        public async Task<StatGeneralResponse> PivotDrilldown(PivotDrilldownQueryParams queryParameters)
        {
            string url = this.Client.CombineURL($"/stat/v1/data/pivot/drilldown", queryParameters);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<StatGeneralResponse>(url, Method.Get);
        }

        public async Task<DrilldownResponse> Drilldown(DrilldownQueryParameters queryParameters)
        {
            string url = this.Client.CombineURL($"/stat/v1/data/drilldown", queryParameters);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DrilldownResponse>(url, Method.Get);
        }

        public async Task<ComparisonResponse> Comparison(ComparisonQueryParams queryParameters)
        {
            string url = this.Client.CombineURL($"/stat/v1/data/comparison", queryParameters);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ComparisonResponse>(url, Method.Get);
        }

        public async Task<ComparisonDrilldownResponse> ComparisonDrilldown(ComparisonDrilldownQueryParams queryParameters)
        {
            string url = this.Client.CombineURL($"/stat/v1/data/comparison/drilldown", queryParameters);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ComparisonDrilldownResponse>(url, Method.Get);
        }

        public async Task<ByTimeResponse> ByTime(ByTimeQueryParameters queryParameters)
        {
            string url = this.Client.CombineURL($"/stat/v1/data/bytime", queryParameters);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ByTimeResponse>(url, Method.Get);
        }
    }
}
