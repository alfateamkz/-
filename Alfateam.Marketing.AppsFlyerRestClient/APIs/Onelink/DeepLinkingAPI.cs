using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.TestConsole.Events.RetrieveEvents;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.AndroidDeepLinking;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.iOSDeepLinking;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Onelink
{
    public class DeepLinkingAPI : AbsAPI
    {
        public DeepLinkingAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<DeepLinkingForAndroidResponse> AndroidDeepLinking(string appId, string afSig, DeepLinkingForAndroidBody body)
        {
            string url = $"https://dls2s.appsflyer.com/v1.0/android/{appId}?af_sig={afSig}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DeepLinkingForAndroidResponse>(url, Method.Post, body);
        }

        public async Task<DeepLinkingForiOSResponse> iOSDeepLinking(string appId, string afSig, DeepLinkingForiOSBody body)
        {
            string url = $"https://dls2s.appsflyer.com/v1.0/ios/{appId}?af_sig={afSig}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DeepLinkingForiOSResponse>(url, Method.Post, body);
        }
    }
}
