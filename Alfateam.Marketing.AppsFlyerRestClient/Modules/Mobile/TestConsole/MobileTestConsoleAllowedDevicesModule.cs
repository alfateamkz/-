using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.GCDAPIForSDKAttributionTesting.ConversionData.GetTheConversionData;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.TestConsole.AllowedDevices.AddDevice;
using Alfateam.Marketing.AppsFlyerRestClient.Models.Mobile.TestConsole.AllowedDevices.DeleteDevice;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Modules.Mobile.TestConsole
{
    public class MobileTestConsoleAllowedDevicesModule : AbsModule
    {
        public MobileTestConsoleAllowedDevicesModule(AppsFlyerClient client) : base(client)
        {
        }

        public async Task<AddDeviceResponse> AddDevice(string appId, AddDeviceBody body)
        {
            string url = $"https://hq1.appsflyer.com/api/test-console/v1.0/app/{appId}/devices";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<AddDeviceResponse>(url, Method.Post, body);
        }

        public async Task<DeleteDeviceResponse> DeleteDevice(string appId, string deviceId)
        {
            string url = $"https://hq1.appsflyer.com/api/test-console/v1.0/app/{appId}/devices/{deviceId}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<DeleteDeviceResponse>(url, Method.Delete);
        }
    }
}
