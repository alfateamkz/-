using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANConversionStudio.CopySKANSchema;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANConversionStudio.GetSKANSchema;
using Alfateam.Marketing.AppsFlyerRestClient.Models.SKAN.SKANCVSchemaAPIForAdvertisers.GetCVSchema;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.SKAN
{
    public class SKANConversionStudioAPI : AbsAPI
    {
        public SKANConversionStudioAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<CopySKANSchemaResponse> CopySKANSchema(IEnumerable<string> appIds)
        {
            string url = $"https://hq1.appsflyer.com/api/conversion-studio-config/v1/app/{string.Join(',', appIds)}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CopySKANSchemaResponse>(url, Method.Post);
        }

        public async Task<GetSKANSchemaResponse> GetSKANSchema(string appId)
        {
            string url = $"https://hq1.appsflyer.com/api/conversion-studio-config/v1/app/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetSKANSchemaResponse>(url, Method.Get);
        }
    }
}
