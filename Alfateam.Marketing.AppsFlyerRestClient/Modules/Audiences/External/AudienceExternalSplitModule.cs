using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceConnections.ListPartner;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceSplit.GetSplit;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceSplit.UpdateSplit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.Audiences.External
{
    public class AudienceExternalSplitModule : AbsModule
    {
        public AudienceExternalSplitModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetSplitPercentagesForAudienceResponse> GetSplitPercentagesForAudience(int audienceId)
        {
            string url = this.Client.CombineURL($"/audiences-external-api/audience/{audienceId}/split_syncs");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetSplitPercentagesForAudienceResponse>(url, Method.Get);
        }

        public async Task<UpdateSplitPercentagesForAudienceResponse> UpdateSplitPercentagesForAudience(int audienceId, UpdateSplitPercentagesForAudienceBody body)
        {
            string url = this.Client.CombineURL($"/audiences-external-api/audience/{audienceId}/split_syncs");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UpdateSplitPercentagesForAudienceResponse>(url, Method.Put, body);
        }
    }
}
