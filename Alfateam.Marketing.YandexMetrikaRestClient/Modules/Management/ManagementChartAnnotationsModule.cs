using Alfateam.Marketing.YandexMetrikaRestClient.Abstractions;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters.GetFilter;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.ChartAnnotations;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.ChartAnnotations.GetChartAnnotations;
using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Modules.Management
{
    public class ManagementChartAnnotationsModule : AbsModule
    {
        public ManagementChartAnnotationsModule(YandexMetrikaClient client) : base(client)
        {
        }

        public async Task<WithChartAnnotationResponse> GetAnnotation(int counterId, long annotationId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/chart_annotation/{annotationId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithChartAnnotationResponse>(url, Method.Get);
        }

        public async Task<GetChartAnnotationsResponse> GetAnnotations(int counterId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/chart_annotations");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetChartAnnotationsResponse>(url, Method.Get);
        }

        public async Task<WithChartAnnotationResponse> EditAnnotation(int counterId, long annotationId, WithChartAnnotationBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/chart_annotation/{annotationId}", body);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithChartAnnotationResponse>(url, Method.Put);
        }

        public async Task<WithChartAnnotationResponse> CreateAnnotation(int counterId, WithChartAnnotationBody body)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/chart_annotations", body);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<WithChartAnnotationResponse>(url, Method.Post);
        }

        public async Task<ManagementGeneralDeleteResponse> DeleteAnnotation(int counterId, long annotationId)
        {
            string url = this.Client.CombineURL($"/management/v1/counter/{counterId}/chart_annotation/{annotationId}");
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ManagementGeneralDeleteResponse>(url, Method.Delete);
        }
    }
}
