using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.Measurements.Engagements;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Measurements.PCConsoleCTVEvents.MeasureFirstAppOpens;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.GCDAPIForSDKAttributionTesting.ConversionData.GetTheConversionData;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.Mobile
{
    public class GCDAPIForSDKAttributionTesting : AbsAPI
    {
        public GCDAPIForSDKAttributionTesting(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<GetTheConversionDataResponse> GetTheConversionData(string appId, GetTheConversionDataQueryParams queryParams)
        {
            string url = this.Client.MakeQueryParams($"https://gcdsdk.appsflyer.com/install_data/v4.0/{appId}", queryParams);
            return await this.Client.MakeRequestAndThrowIfNotSuccess<GetTheConversionDataResponse>(url, Method.Get);
        }
    }
}
