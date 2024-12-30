using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.ChartAnnotations;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Segments;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Segments.GetSegmentsForCounter;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementSegmentsModule : AbsModule
    {
        public ManagementSegmentsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithSegmentResponse> GetSegment(int counterId, long segmentId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/apisegment/segment/{segmentId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithSegmentResponse>(url, Method.Get);
        }

        public async Task<GetSegmentsForCounterResponse> GetSegmentsForCounter(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/apisegment/segments");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetSegmentsForCounterResponse>(url, Method.Get);
        }

        public async Task<WithSegmentResponse> EditSegment(int counterId, long segmentId, WithSegmentBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/apisegment/segment/{segmentId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithSegmentResponse>(url, Method.Put, body);
        }

        public async Task<WithSegmentResponse> CreateSegment(int counterId, WithSegmentBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/apisegment/segments");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithSegmentResponse>(url, Method.Post, body);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteSegment(int counterId, long segmentId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/apisegment/segment/{segmentId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }
    }
}
