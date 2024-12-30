using Alfateam.Marketing.AppsFlyerRestClient.APIs;
using Alfateam.Marketing.AppsFlyerRestClient.Exceptions;
using Newtonsoft.Json;
using RestSharp;

namespace Alfateam.Marketing.AppsFlyerRestClient
{
    public class AppsFlyerClient
    {
        public const string HOST = "https://hq1.appsflyer.com/api/";
        public readonly RestClient RestClient;


        public readonly string Token;
        public string AppId { get; set; }
        public AppsFlyerClient(string token, string appId)
        {
            RestClient = new RestClient();

            Token = token;
            AppId = appId;

            AnalyticsAPI = new AnalyticsAPI(this);
            AudiencesAPI = new AudiencesAPI(this);
            ManagementAPI = new ManagementAPI(this);
            MarketplaceAPI = new MarketplaceAPI(this);
            MeasurementsAPI = new MeasurementsAPI(this);
            MobileAPI = new MobileAPI(this);
            OnelinkAPI = new OnelinkAPI(this);
            RawDataReportAPI = new RawDataReportAPI(this);
            ROIAPI = new ROIAPI(this);
            SKANAPI = new SKANAPI(this);
        }



        public AnalyticsAPI AnalyticsAPI { get; private set; }
        public AudiencesAPI AudiencesAPI { get; private set; }
        public ManagementAPI ManagementAPI { get; private set; }
        public MarketplaceAPI MarketplaceAPI { get; private set; }
        public MeasurementsAPI MeasurementsAPI { get; private set; }
        public MobileAPI MobileAPI { get; private set; }
        public OnelinkAPI OnelinkAPI { get; private set; }
        public RawDataReportAPI RawDataReportAPI { get; private set; }
        public ROIAPI ROIAPI { get; private set; }
        public SKANAPI SKANAPI { get; private set; }








        #region Internal methods

        internal string CombineURL(string path)
        {
            return AppsFlyerClient.HOST + path;
        }
        internal string CombineURL(string path, object queryParamsModel)
        {
            return MakeQueryParams(AppsFlyerClient.HOST + path, queryParamsModel);
        }

        internal string MakeQueryParams(string url, object queryParamsModel)
        {
            string urlWithParams = url;

            var props = queryParamsModel.GetType().GetProperties();

            int counter = 1;
            foreach (var prop in props)
            {
                string paramName = prop.Name;
                if (prop.GetCustomAttributes(false).Any(o => o is JsonPropertyAttribute))
                {
                    var attr = prop.GetCustomAttributes(false).FirstOrDefault(o => o is JsonPropertyAttribute) as JsonPropertyAttribute;
                    paramName = attr.PropertyName;
                }

                if (counter == 1)
                {
                    urlWithParams += $"?{paramName}={prop.GetValue(queryParamsModel)}";
                }
                else
                {
                    urlWithParams += $"&{paramName}={prop.GetValue(queryParamsModel)}";
                }
                counter++;
            }

            return urlWithParams;
        }


        internal async Task MakeRequestAndThrowIfNotSuccess(string url, Method method, int expectedStatusCode = 200, object body = null)
        {
            var response = await MakeRequest(url, Method.Get);
            if ((int)response.StatusCode != expectedStatusCode)
            {
                throw new AppsFlyerRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
        }
        internal async Task<T> MakeRequestAndThrowIfNotSuccess<T>(string url, Method method, object body = null, int expectedStatusCode = 200)
        {
            var response = await MakeRequest(url, Method.Get);
            if ((int)response.StatusCode != expectedStatusCode)
            {
                throw new AppsFlyerRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
            return ParseSuccessJSONOrThrowError<T>(response);
        }

        internal async Task<RestResponse> MakeRequest(string url, Method method, object body = null)
        {
            var req = new RestRequest
            {
                Method = method,
                Resource = url,
            };
            req = req.AddHeader("Content-Type", "application/json");
            req = req.AddHeader("Authorization", Token);

            if (body != null)
            {
                req = req.AddBody(body);
            }

            return await RestClient.ExecuteAsync(req);
        }
        internal T ParseSuccessJSONOrThrowError<T>(RestResponse response)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(response.Content, new JsonSerializerSettings
                {

                });
                return obj;
            }
            catch
            {
                throw new AppsFlyerRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
        }

        #endregion
    }
}
