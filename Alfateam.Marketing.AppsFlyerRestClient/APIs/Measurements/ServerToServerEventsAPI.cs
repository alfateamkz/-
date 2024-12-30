using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.Measurements;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PreloadMeasurement.DownloadEvents;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.ServerToServerEvents.InAppEvents.SendEvent;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Measurements
{
    public class ServerToServerEventsAPI : AbsAPI
    {
        public ServerToServerEventsAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<SendEventResponse> SendEvent(string appId, SendEventBody body)
        {
            string url = $"https://api3.appsflyer.com/inappevent/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<SendEventResponse>(url, Method.Post, body: body);
        }
    }
}
