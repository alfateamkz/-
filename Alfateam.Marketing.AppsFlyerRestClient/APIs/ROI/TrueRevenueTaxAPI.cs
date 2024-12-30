using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Onelink.OnelinkModule.CreateOneLinkAttributionLink;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.TrueRevenueTax.CreateTaxRule;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.TrueRevenueTax.GetTaxesList;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.ROI
{
    public class TrueRevenueTaxAPI : AbsAPI
    {
        public TrueRevenueTaxAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetTaxesListResponse> GetTaxesList(string appId, GetTaxesListQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://hq1.appsflyer.com/api/stores-taxes/v1.0/tax_rates/app/{appId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetTaxesListResponse>(url, Method.Get);
        }

        public async Task<CreateTaxRuleResponse> CreateTaxRule(string appId, CreateTaxRuleBody body)
        {
            string url = $"https://hq1.appsflyer.com/api/stores-taxes/v1.0/tax_rates/app/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CreateTaxRuleResponse>(url, Method.Post, body);
        }
    }
}
