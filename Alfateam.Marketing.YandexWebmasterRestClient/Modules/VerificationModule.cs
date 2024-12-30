using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Enums.Verification;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Verification;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Verification.HostOwnersGet;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Verification.VerificationPost;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class VerificationModule : AbsModule
    {
        public VerificationModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<VerificationPostResponse> HostVerificationPost(string hostId, VerificationPostQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/verification", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<VerificationPostResponse>(url, Method.Post);
        }

        public async Task<VerificationModel> HostVerificationGet(string hostId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/verification");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<VerificationModel>(url, Method.Get);
        }

        public async Task<HostOwnersGetResponse> HostOwnersGet(string hostId)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/owners");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<HostOwnersGetResponse>(url, Method.Get);
        }
    }
}
