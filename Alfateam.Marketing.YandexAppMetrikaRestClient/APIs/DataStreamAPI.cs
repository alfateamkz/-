using Alfateam.Marketing.YandexAppMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs.Clicks;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.Logs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream.Status;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream.Data;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Models.DataStream;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient.APIs
{
    public class DataStreamAPI : AbsAPI
    {
        public DataStreamAPI(YandexAppMetrikaClient client) : base(client)
        {
        }

        public async Task<StatusResponse> Status(int applicationId)
        {
            string url = this.Client.CombineURL($"/datastream/v1/application/{applicationId}/status");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<StatusResponse>(url, Method.Get);
        }

        public async Task<byte[]> Data(int applicationId, DataQueryParams queryParams)
        {
            string url = this.Client.CombineURL($"/datastream/v1/application/{applicationId}/data", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<byte[]>(url, Method.Get);
        }

        public async Task<WithDataStreamSettingsResponse> Settings(int applicationId)
        {
            string url = this.Client.CombineURL($"/datastream/v1/application/{applicationId}/datastream/settings");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithDataStreamSettingsResponse>(url, Method.Get);
        }

        public async Task<WithDataStreamSettingsResponse> SettingsPost(int applicationId, WithDataStreamSettingsBody body)
        {
            string url = this.Client.CombineURL($"/datastream/v1/application/{applicationId}/datastream/settings");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithDataStreamSettingsResponse>(url, Method.Post, body);
        }
    }
}
