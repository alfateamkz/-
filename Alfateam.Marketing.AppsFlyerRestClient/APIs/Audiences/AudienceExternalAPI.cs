using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AccountConnections;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AccountSplits;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.ActiveAudiences;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.AudienceUpload;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.CreateAudience;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Audiences.External.PausesAudience;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Management.UserManagement.ManagingUsersInBulk.CreateBulkUsers;
using Alfateam.Marketing.AppsFlyerRestClient.Modules.Audiences.External;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Audiences
{
    public class AudienceExternalAPI : AbsAPI
    {
        public AudienceExternalAPI(AppsFlyerClient client) : base(client)
        {
            AudienceConnections = new AudienceExternalConnectionsModule(this.Client);
            Split = new AudienceExternalSplitModule(this.Client);
        }

        public AudienceExternalConnectionsModule AudienceConnections { get; private set; }
        public AudienceExternalSplitModule Split { get; private set; }

        public async Task<CreateNewImportedAudienceResponse> CreateNewImportedAudience(CreateNewImportedAudienceBody body)
        {
            string url = this.Client.CombineURL($"/audiences-external-api/audience");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CreateNewImportedAudienceResponse>(url, Method.Post, body);
        }

        public async Task<UploadAudienceToPartnersNowResponse> UploadAudienceToPartnersNow(int audienceId)
        {
            string url = this.Client.CombineURL($"/audiences-external-api/audience/{audienceId}/upload_now");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UploadAudienceToPartnersNowResponse>(url, Method.Post);
        }

        public async Task<ListPartnerConnectionsForAccountResponse> ListPartnerConnectionsForAccount()
        {
            string url = this.Client.CombineURL($"/audiences-external-api/connections");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ListPartnerConnectionsForAccountResponse>(url, Method.Get);
        }

        public async Task<GetSplitPercentagesForAccountResponse> GetSplitPercentagesForAccount()
        {
            string url = this.Client.CombineURL($"/audiences-external-api/split_syncs");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetSplitPercentagesForAccountResponse>(url, Method.Get);
        }

        public async Task<GetActiveAudiencesForAccountResponse> GetActiveAudiencesForAccount()
        {
            string url = this.Client.CombineURL($"/audiences-external-api/active-audiences");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetActiveAudiencesForAccountResponse>(url, Method.Get);
        }

        public async Task<PauseAudienceResponse> PauseAudience(PauseAudienceBody body)
        {
            string url = this.Client.CombineURL($"/audiences-external-api/pause");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<PauseAudienceResponse>(url, Method.Post, body);
        }
    }
}
