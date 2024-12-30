using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling.AddModify;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Analytics.Cohort;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Analytics
{
    public class CohortAPI : AbsAPI
    {
        public CohortAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<CohortReportResponse> CreateCohortReport(string appId, CohortReportBody body)
        {
            string url = this.Client.CombineURL($"/cohorts/v1/data/app/{appId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CohortReportResponse>(url, Method.Post, body);
        }
    }
}
