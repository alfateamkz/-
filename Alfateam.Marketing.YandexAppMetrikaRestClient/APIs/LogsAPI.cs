using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports.Data;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Reports;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.Clicks;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.Installations;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.Postbacks;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.Events;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.ECommerce;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.Profiles;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.RevenueEvents;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.AdRevenueEvents;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.Deeplinks;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.Crashes;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.Errors;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.PushTokens;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.SessionsStarts;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.APIs
{
    public class LogsAPI : AbsAPI
    {
        public LogsAPI(YandexAppMetrikaClient client) : base(client)
        {
        }

        public async Task<ClicksResponse> Clicks(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/clicks.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ClicksResponse>(url, Method.Get);
        }

        public async Task<string> ClicksCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/clicks.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<InstallationsResponse> Installations(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/installations.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<InstallationsResponse>(url, Method.Get);
        }

        public async Task<string> InstallationsCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/installations.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<PostbacksResponse> Postbacks(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/postbacks.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<PostbacksResponse>(url, Method.Get);
        }

        public async Task<string> PostbacksCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/postbacks.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<EventsResponse> Events(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/events.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<EventsResponse>(url, Method.Get);
        }

        public async Task<string> EventsCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/events.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<ECommerceResponse> ECommerce(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/ecommerce_events.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ECommerceResponse>(url, Method.Get);
        }

        public async Task<string> ECommerceCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/ecommerce_events.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<ProfilesResponse> Profiles(ProfilesQueryParameters queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/profiles_v2.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ProfilesResponse>(url, Method.Get);
        }

        public async Task<string> ProfilesCSV(ProfilesQueryParameters queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/profiles_v2.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<RevenueEventsResponse> RevenueEvents(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/revenue_events.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<RevenueEventsResponse>(url, Method.Get);
        }

        public async Task<string> RevenueEventsCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/revenue_events.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<AdRevenueEventsResponse> AdRevenueEvents(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/ad_revenue_events.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<AdRevenueEventsResponse>(url, Method.Get);
        }

        public async Task<string> AdRevenueEventsCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/ad_revenue_events.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<DeeplinksResponse> Deeplinks(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/deeplinks.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DeeplinksResponse>(url, Method.Get);
        }

        public async Task<string> DeeplinksCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/deeplinks.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<CrashesResponse> Crashes(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/crashes.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<CrashesResponse>(url, Method.Get);
        }

        public async Task<string> CrashesCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/crashes.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<ErrorsResponse> Errors(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/errors.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ErrorsResponse>(url, Method.Get);
        }

        public async Task<string> ErrorsCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/errors.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<PushTokensResponse> PushTokens(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/push_tokens.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<PushTokensResponse>(url, Method.Get);
        }

        public async Task<string> PushTokensCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/push_tokens.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }

        public async Task<SessionsStartsResponse> SessionsStarts(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/sessions_starts.json", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<SessionsStartsResponse>(url, Method.Get);
        }

        public async Task<string> SessionsStartsCSV(LogsGeneralQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/logs/v1/export/sessions_starts.csv", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<string>(url, Method.Get);
        }
    }
}
