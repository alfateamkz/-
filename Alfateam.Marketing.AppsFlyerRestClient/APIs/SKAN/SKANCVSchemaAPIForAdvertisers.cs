using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdNetworks.GetSKAN3;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdvertisers.GetCVSchema;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.SKAN
{
    public class SKANCVSchemaAPIForAdvertisers : AbsAPI
    {
        public SKANCVSchemaAPIForAdvertisers(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetCVSchemaResponse> GetCVSchema(string appId)
        {
            string url = $"https://hq1.appsflyer.com/api/skan-pull-cs-api/v1/conversion-studio-schema/app/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetCVSchemaResponse>(url, Method.Get);
        }
    }
}
