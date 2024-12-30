using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PreloadC2SMeasurement.DownloadEvents;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PreloadMeasurement.DownloadEvents;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Measurements
{
    public class PreloadMeasurementAPI : AbsAPI
    {
        public PreloadMeasurementAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<DownloadEventResponse> DownloadEvent(string appId, DownloadEventBody body)
        {
            string url = $"https://engagements.appsflyer.com/v1.0/s2s/download/app/android/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DownloadEventResponse>(url, Method.Post, body: body, expectedStatusCode: 202);
        }
    }
}
