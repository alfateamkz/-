using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PCConsoleCTVEvents.MeasureFirstAppOpens;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PreloadC2SMeasurement.DownloadEvents;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Measurements
{
    public class PreloadC2SMeasurementAPI : AbsAPI
    {
        public PreloadC2SMeasurementAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<PreloadC2SDownloadEventResponse> DownloadEvent(string appId, PreloadC2SDownloadEventBody body)
        {
            string url = $"https://engagements.appsflyer.com/v1.0/c2s/download/app/android/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<PreloadC2SDownloadEventResponse>(url, Method.Post, body: body, expectedStatusCode: 202);
        }
    }
}
