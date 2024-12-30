using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.Incost.IncostJobStatus;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN3;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN4;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.SKAN
{
    public class SKANCVSchemaAPIForAdNetworks : AbsAPI
    {
        public SKANCVSchemaAPIForAdNetworks(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetSKAN3CVSchemaResponse> GetSKAN3(string appId)
        {
            string url = $"https://hq1.appsflyer.com/api/skad/conversion_schema/v1?app_id={appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetSKAN3CVSchemaResponse>(url, Method.Get);
        }

        public async Task<GetSKAN4CVSchemaResponse> GetSKAN4(string appId)
        {
            string url = $"https://hq1.appsflyer.com/api/skad/conversion_schema/v2?app_id={appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetSKAN4CVSchemaResponse>(url, Method.Get);
        }
    }
}
