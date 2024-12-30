using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Enums;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Analytics.Cohort;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.Engagements.ClickEngagement.ClickEngagementPost;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.Engagements.ClickEngagement.GetClickEngagement;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.Measurements.Engagements
{
    public class MeasurementEngagementsClickModule : AbsModule
    {
        public MeasurementEngagementsClickModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetClickEngagementResponse> GetClickEngagement(string appId, MeasurementEngagementPlatform platform, GetClickEngagementQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://engagements.appsflyer.com/v1.0/s2s/click/app/{platform}/{appId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetClickEngagementResponse>(url, Method.Get);
        }

        public async Task<ClickEngagementPostResponse> ClickEngagementPost(string appId, MeasurementEngagementPlatform platform, ClickEngagementPostBody body)
        {
            string url = $"https://engagements.appsflyer.com/v1.0/s2s/click/app/{platform}/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ClickEngagementPostResponse>(url, Method.Post, body);
        }
    }
}
