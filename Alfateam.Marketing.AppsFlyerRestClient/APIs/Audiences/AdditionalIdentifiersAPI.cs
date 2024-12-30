using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.CreateAudience;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling.AddModify;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.Identifiers.AdditionalIdentifiersHandling.Remove;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Audiences
{
    public class AdditionalIdentifiersAPI : AbsAPI
    {
        public AdditionalIdentifiersAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<AIHAddModifyRemoveIdentifierResponse> AddModifyIdentifier(string appId, AIHAddModifyIdentifierBody body)
        {
            string url = this.Client.CombineURL($"/audience-bulk-api/v1/additional-identifiers/app/{appId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<AIHAddModifyRemoveIdentifierResponse>(url, Method.Put, body);
        }

        public async Task<AIHAddModifyRemoveIdentifierResponse> RemoveIdentifier(string appId, AIHRemoveIdentifierBody body)
        {
            string url = this.Client.CombineURL($"/audience-bulk-api/v1/additional-identifiers/app/{appId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<AIHAddModifyRemoveIdentifierResponse>(url, Method.Put, body);
        }
    }
}
