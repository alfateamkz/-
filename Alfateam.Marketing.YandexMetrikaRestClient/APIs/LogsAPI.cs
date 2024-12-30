using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Logs;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Logs.CreateLogRequest;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Logs.Download;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Logs.Evaluate;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Logs.GetLogRequests;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Stat.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.APIs
{
    public class LogsAPI : AbsAPI
    {
        public LogsAPI(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<GetLogRequestsResponse> GetLogRequests(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/logrequests");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetLogRequestsResponse>(url, Method.Get);
        }

        public async Task<WithLogRequestResponse> CreateLogRequest(int counterId, CreateLogRequestQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/logrequests", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithLogRequestResponse>(url, Method.Post);
        }

        public async Task<WithLogRequestResponse> Clean(int counterId, int requestId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/logrequest/{requestId}/clean");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithLogRequestResponse>(url, Method.Post);
        }

        public async Task<WithLogRequestResponse> Cancel(int counterId, int requestId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/logrequest/{requestId}/cancel");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithLogRequestResponse>(url, Method.Post);
        }

        public async Task<EvaluateResponse> Evaluate(int counterId, EvaluateQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/logrequests/evaluate", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<EvaluateResponse>(url, Method.Get);
        }

        public async Task<WithLogRequestResponse> GetLogRequest(int counterId, int requestId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/logrequest/{requestId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithLogRequestResponse>(url, Method.Get);
        }

        public async Task<DownloadResponse> Download(int counterId, int requestId,int partNumber)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/logrequest/{requestId}/part/{partNumber}/download");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DownloadResponse>(url, Method.Get);
        }
    }
}
