using Alfateam.Marketing.AppsFlyerRestClient.Abstractions;
using Alfateam.Marketing.AppsFlyerRestClient.Enums.RawDataReport.PushAPIConfiguration;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.EventTypes.RetrievePerAttributingEntity;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.ManagePushAPIConfiguration.GetPushAPIConfiguration;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.MessageFields.RetrievePerPlatform;
using Alfateam.Marketing.AppsFlyerRestClient.Models.RawDataReport.PushAPIConfiguration.URLValidation.ValidateURL;
using Alfateam.Marketing.AppsFlyerRestClient.Modules.RawDataReport.PushAPIConfiguration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.APIs.RawDataReport
{
    public class PushAPIConfigurationAPI : AbsAPI
    {
        public PushAPIConfigurationAPI(AppsFlyerClient client) : base(client)
        {
            AuthenticationToken = new RawPushAPIAuthenticationTokenModule(this.Client);
            ManagePushAPIConfiguration = new RawPushAPIManagePushAPIConfModule(this.Client);
        }

        public RawPushAPIAuthenticationTokenModule AuthenticationToken { get; private set; }
        public RawPushAPIManagePushAPIConfModule ManagePushAPIConfiguration { get; private set; }

        public async Task<RetrievePerAttributingEntityResponse> RetrievePerAttributingEntity(PushAPIConfigAttributingEntityType attributingEntity)
        {
            string url = $"https://hq1.appsflyer.com/api/pushapi/v1.0/event-types/{JsonConvert.SerializeObject(attributingEntity)}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<RetrievePerAttributingEntityResponse>(url, Method.Get);
        }

        public async Task<RetrievePerPlatformResponse> RetrievePerPlatform(PushAPIConfigPlatform platform)
        {
            string url = $"https://hq1.appsflyer.com/api/pushapi/v1.0/fields/{JsonConvert.SerializeObject(platform)}";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<RetrievePerPlatformResponse>(url, Method.Get);
        }

        public async Task<ValidateURLResponse> ValidateURL(ValidateURLBody body)
        {
            string url = $"https://hq1.appsflyer.com/api/pushapi/v1.0/validate-url";
            return await this.Client.MakeRequestAndThrowIfNotSuccess<ValidateURLResponse>(url, Method.Post, body);
        }
    }
}
