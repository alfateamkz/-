using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.Engagements.ClickEngagement.ClickEngagementPost;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.Engagements.ClickEngagement.GetClickEngagement;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.Engagements.ImpressionEngagement.GetImpressionEngagement;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.Engagements.ImpressionEngagement.ImpressionEngagementPost;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.Measurements.Engagements
{
    public class MeasurementEngagementsImpressionModule : AbsModule
    {
        public MeasurementEngagementsImpressionModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetImpressionEngagementResponse> GetImpressionEngagement(string appId, MeasurementEngagementPlatform platform, GetImpressionEngagementQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://engagements.appsflyer.com/v1.0/s2s/impression/app/{platform}/{appId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetImpressionEngagementResponse>(url, Method.Get);
        }

        public async Task<ImpressionEngagementPostResponse> ImpressionEngagementPost(string appId, MeasurementEngagementPlatform platform, ImpressionEngagementPostBody body)
        {
            string url = $"https://engagements.appsflyer.com/v1.0/s2s/impression/app/{platform}/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ImpressionEngagementPostResponse>(url, Method.Post, body);
        }
    }
}
