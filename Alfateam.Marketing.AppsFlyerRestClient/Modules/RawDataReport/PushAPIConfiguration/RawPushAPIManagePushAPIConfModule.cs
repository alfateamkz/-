using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.AuthenticationToken.DeletePushAPIAuthenticationToken;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.AuthenticationToken.SetPushAPIAuthenticationToken;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.ManagePushAPIConfiguration.GetPushAPIConfiguration;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.ManagePushAPIConfiguration.UpdatePushAPIConfiguration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.RawDataReport.PushAPIConfiguration
{
    public class RawPushAPIManagePushAPIConfModule : AbsModule
    {
        public RawPushAPIManagePushAPIConfModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<UpdatePushAPIConfigurationResponse> UpdatePushAPIConfiguration(string appId, UpdatePushAPIConfigurationBody body)
        {
            string url = $"https://hq1.appsflyer.com/api/pushapi/v1.0/app/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UpdatePushAPIConfigurationResponse>(url, Method.Put, body);
        }

        public async Task<GetPushAPIConfigurationResponse> GetPushAPIConfiguration(string appId)
        {
            string url = $"https://hq1.appsflyer.com/api/pushapi/v1.0/app/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetPushAPIConfigurationResponse>(url, Method.Get);
        }
    }
}
