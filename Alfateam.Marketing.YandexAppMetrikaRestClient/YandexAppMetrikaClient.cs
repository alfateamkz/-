using Alfateam.Marketing.YandexAppMetrikaRestClient.APIs;
using Alfateam.Marketing.YandexAppMetrikaRestClient.Exceptions;
using Newtonsoft.Json;
using RestSharp;

namespace Alfateam.Marketing.YandexAppMetrikaRestClient
{
    public class YandexAppMetrikaClient
    {
        public const string HOST = "https://api.appmetrica.yandex.ru";
        public readonly RestClient RestClient;

        public string OAUTH_TOKEN;

        public YandexAppMetrikaClient()
        {
            RestClient = new RestClient();

            DataStream = new DataStreamAPI(this);
            Logs = new LogsAPI(this);
            Management = new ManagementAPI(this);
            Post = new PostAPI(this);
            Push = new PushAPI(this);
            Reports = new ReportsAPI(this);
        }

        public YandexAppMetrikaClient(string oauthToken) : base()
        {
            OAUTH_TOKEN = oauthToken;
        }

        public DataStreamAPI DataStream { get; private set; }
        public LogsAPI Logs { get; private set; }
        public ManagementAPI Management { get; private set; }
        public PostAPI Post { get; private set; }
        public PushAPI Push { get; private set; }
        public ReportsAPI Reports { get; private set; }




        #region Internal methods

        internal string CombineURL(string path)
        {
            return YandexAppMetrikaClient.HOST + path;
        }
        internal string CombineURL(string path, object queryParamsModel)
        {
            return MakeQueryParams(YandexAppMetrikaClient.HOST + path, queryParamsModel);
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
                throw new AppMetrikaRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
        }
        internal async Task<T> MakeRequestAndThrowIfNotSuccess<T>(string url, Method method, object body = null)
        {
            var response = await MakeRequest(url, Method.Get);
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
            req = req.AddHeader("Authorization", OAUTH_TOKEN);

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
                throw new AppMetrikaRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
        }

        #endregion

    }
}
