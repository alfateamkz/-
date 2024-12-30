using Alfateam.Marketing.YandexWebmasterRestClient.Abstractions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.SiteQuality.GetSQIHistory;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.SiteQuality.NewFolder;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Verification.VerificationPost;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexWebmasterRestClient.Modules
{
    public class SiteQualityModule : AbsModule
    {
        public SiteQualityModule(YandexWebmasterClient client) : base(client)
        {
        }

        public async Task<GetSQIHistoryResponse> HostVerificationPost(string hostId, GetSQIHistoryQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/user/{this.Client.UserID}/hosts/{hostId}/sqi-history", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetSQIHistoryResponse>(url, Method.Get);
        }
    }
}
