using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.Measurements;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.WebServerToServer.EventsManagement.AssociateCustomerUserID;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.WebServerToServer.EventsManagement.SendEvent;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Measurements
{
    public class WebServerToServerAPI : AbsAPI
    {
        public WebServerToServerAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<AssociateCustomerUserIDResponse> AssociateCustomerUserID(string bundleId, AssociateCustomerUserIDBody body)
        {
            string url = $"https://webs2s.appsflyer.com/v1/{bundleId}/setcuid";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<AssociateCustomerUserIDResponse>(url, Method.Post, body);
        }

        public async Task<SendEventResponse> SendEvent(string bundleId, WSToSEventManagementSendEventBody body)
        {
            string url = $"https://webs2s.appsflyer.com/v1/{bundleId}/event";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<SendEventResponse>(url, Method.Post, body);
        }
    }
}
