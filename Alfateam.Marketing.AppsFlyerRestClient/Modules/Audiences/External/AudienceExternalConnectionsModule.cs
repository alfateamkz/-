using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceConnections.ConnectAudience;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceConnections.ListPartner;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.CreateAudience;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.Audiences.External
{
    public class AudienceExternalConnectionsModule : AbsModule
    {
        public AudienceExternalConnectionsModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<ListPartnerConnectionsForAudienceResponse> ListPartnerConnectionsForAudience(int audienceId)
        {
            string url = this.Client.CombineURL($"/audiences-external-api/audience/{audienceId}/connections");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ListPartnerConnectionsForAudienceResponse>(url, Method.Get);
        }

        public async Task<ConnectAudienceToExistingPartnersResponse> ConnectAudienceToExistingPartners(int audienceId, ConnectAudienceToExistingPartnersBody body)
        {
            string url = this.Client.CombineURL($"/audiences-external-api/audience/{audienceId}/connections");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ConnectAudienceToExistingPartnersResponse>(url, Method.Post, body);
        }
    }
}
