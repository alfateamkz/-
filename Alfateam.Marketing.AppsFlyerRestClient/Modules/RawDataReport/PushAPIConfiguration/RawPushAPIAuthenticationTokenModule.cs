using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.AuthenticationToken.DeletePushAPIAuthenticationToken;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.AuthenticationToken.SetPushAPIAuthenticationToken;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.RawDataPull;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.RawDataReport.PushAPIConfiguration
{
    public class RawPushAPIAuthenticationTokenModule : AbsModule
    {
        public RawPushAPIAuthenticationTokenModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<DeletePushAPIAuthenticationTokenResponse> DeletePushAPIAuthenticationToken(string appId)
        {
            string url = $"https://hq1.appsflyer.com/api/pushapi/v1.0/tokens/app/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DeletePushAPIAuthenticationTokenResponse>(url, Method.Delete);
        }

        public async Task<SetPushAPIAuthenticationTokenResponse> SetPushAPIAuthenticationToken(string appId, SetPushAPIAuthenticationTokenBody body)
        {
            string url = $"https://hq1.appsflyer.com/api/pushapi/v1.0/tokens/app/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<SetPushAPIAuthenticationTokenResponse>(url, Method.Put, body);
        }
    }
}
