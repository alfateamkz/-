using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.DeepLinking.AndroidDeepLinking;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.OnelinkModule.CreateOneLinkAttributionLink;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.OnelinkModule.GetOneLinkAttributionLink;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.OnelinkModule.UpdateOneLinkAttributionLink;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Onelink
{
    public class OnelinkModuleAPI : AbsAPI
    {
        public OnelinkModuleAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<string> CreateOneLinkAttributionLink(string onelinkId, CreateOneLinkAttributionLinkBody body)
        {
            string url = $"https://onelink.appsflyer.com/shortlink/v1/{onelinkId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Post, body);
        }

        public async Task<GetOneLinkAttributionLinkResponse> GetOneLinkAttributionLink(string onelinkId)
        {
            string url = $"https://onelink.appsflyer.com/shortlink/v1/{onelinkId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetOneLinkAttributionLinkResponse>(url, Method.Get);
        }

        public async Task<string> UpdateOneLinkAttributionLink(string onelinkId, string id, UpdateOneLinkAttributionLinkBody body)
        {
            string url = $"https://onelink.appsflyer.com/shortlink/v1/{onelinkId}?id={id}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Put, body);
        }

        public async Task<string> DeleteOneLinkAttributionLink(string onelinkId, string id)
        {
            string url = $"https://onelink.appsflyer.com/shortlink/v1/{onelinkId}?id={id}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Delete);
        }
    }
}
