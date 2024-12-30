using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.Engagements.ClickEngagement.GetClickEngagement;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PCConsoleCTVEvents.MeasureFirstAppOpens;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PCConsoleCTVEvents.MeasureInAppEvents;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PCConsoleCTVEvents.MeasureSessions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Measurements
{
    public class PCConsoleCTVEventsAPI : AbsAPI
    {
        public PCConsoleCTVEventsAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<MeasureFirstAppOpensResponse> MeasureFirstAppOpens(string appId, MeasurementEngagementPlatform platform, MeasureFirstAppOpensBody body)
        {
            string url = $"https://events.appsflyer.com/v1.0/s2s/first_open/app/{platform}/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<MeasureFirstAppOpensResponse>(url, Method.Post, body: body, expectedStatusCode: 202);
        }

        public async Task<MeasureSessionsResponse> MeasureSessions(string appId, MeasurementEngagementPlatform platform, MeasureSessionsBody body)
        {
            string url = $"https://events.appsflyer.com/v1.0/s2s/inapp/app/{platform}/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<MeasureSessionsResponse>(url, Method.Post, expectedStatusCode: 202);
        }

        public async Task MeasureInAppEvents(string appId, MeasurementEngagementPlatform platform, MeasureInAppEventsBody body)
        {
            string url = $"https://events.appsflyer.com/v1.0/s2s/inapp/app/{platform}/{appId}";
            await this.Client.MakeRequestAndThrowIfNotSuccess(url, Method.Post, expectedStatusCode: 202);
        }
    }
}
