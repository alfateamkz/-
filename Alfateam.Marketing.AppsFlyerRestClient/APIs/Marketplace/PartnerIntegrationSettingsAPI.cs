using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Marketplace;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.ActiveIntegrations.IntegrationParameters;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.ActiveIntegrations.Integrations;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.GooglePlayInstallReferrer;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.IntegrationSettings;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Marketplace.PartnerIntegrationSettings.UniquePartnerIntegrationParameters;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Marketplace
{
    public class PartnerIntegrationSettingsAPI : AbsAPI
    {
        public PartnerIntegrationSettingsAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetAListOfUniqueParametersResponse> GetListOfUniqueParameters(string pid, MarketplacePlatform platform)
        {
            string url = this.Client.CombineURL($"/app-integrations/v1/partner-params/{pid}/{JsonConvert.SerializeObject(platform)}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetAListOfUniqueParametersResponse>(url, Method.Get);
        }

        public async Task<GetActiveIntegrationParametersResponse> GetActiveIntegrationParameters(string appid)
        {
            string url = this.Client.CombineURL($"/app-integrations/v1/integrations/{appid}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetActiveIntegrationParametersResponse>(url, Method.Get);
        }

        public async Task<GetActiveIntegrationsResponse> GetActiveIntegrations()
        {
            string url = this.Client.CombineURL($"/app-integrations/v1/integrations");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetActiveIntegrationsResponse>(url, Method.Get);
        }

        public async Task<CopyPartnerIntegrationSettingsResponse> CopyPartnerIntegrationSettings(CopyPartnerIntegrationSettingsBody body)
        {
            string url = this.Client.CombineURL($"/app-integrations/v1/copy");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CopyPartnerIntegrationSettingsResponse>(url, Method.Post, body);
        }

        public async Task<SetInstallReferrerDecryptionKeyResponse> SetInstallReferrerDecryptionKey(SetInstallReferrerDecryptionKeyBody body)
        {
            string url = this.Client.CombineURL($"/app-integrations/v1/integration-params");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<SetInstallReferrerDecryptionKeyResponse>(url, Method.Post, body);
        }
    }
}
