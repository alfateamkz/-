using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.SetIntegration;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.TrueRevenueTax.GetTaxesList;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.ROI
{
    public class AdRevenueAccountIntegrationsAPI : AbsAPI
    {
        public AdRevenueAccountIntegrationsAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<IEnumerable<AdRevenueAccountIntegration>> ListIntegration(string appId, GetTaxesListQueryParams queryParams)
        {
            string url = "https://hq1.appsflyer.com/api/adrevenue/v1.0/integrations";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<IEnumerable<AdRevenueAccountIntegration>>(url, Method.Get);
        }

        public async Task<SetIntegrationResponse> SetIntegration(string appId, SetIntegrationBody body)
        {
            string url = $"https://hq1.appsflyer.com/api/adrevenue/v1.0/integrations";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<SetIntegrationResponse>(url, Method.Post, body);
        }
    }
}
