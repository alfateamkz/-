using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.Incost.IncostJobStatus;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.Incost.IncostUploader;
using Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.TrueRevenueTax.GetTaxesList;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.ROI
{
    public class IncostAPI : AbsAPI
    {
        public IncostAPI(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<UploadCostDataResponse> UploadCostData(string appId, UploadCostDataBody body)
        {
            string url = $"https://hq1.appsflyer.com/api/incost-uploader/v1/data/app/{appId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<UploadCostDataResponse>(url, Method.Post, body);
        }

        public async Task<GetJobStatusResponse> GetJobStatus(string appId, string jobId)
        {
            string url = $"https://hq1.appsflyer.com/api/incost-jobstatus/v1/data/app/{appId}/job/{jobId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetJobStatusResponse>(url, Method.Get);
        }
    }
}
