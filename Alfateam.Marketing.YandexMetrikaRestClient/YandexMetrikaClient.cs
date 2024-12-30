using Alfateam.Marketing.YandexMetrikaRestClient.APIs;
using Alfateam.Marketing.YandexMetrikaRestClient.Exceptions;
using Newtonsoft.Json;
using RestSharp;

namespace Alfateam.Marketing.YandexMetrikaRestClient
{
    public class YandexMetrikaClient
    {
        public const string HOST = "https://api-metrika.yandex.net";
        public readonly RestClient RestClient;

        public string OAUTH_TOKEN;


        public YandexMetrikaClient()
        {
            RestClient = new RestClient();

            DataImportAPI = new DataImportAPI(this);
            LogsAPI = new LogsAPI(this);
            ManagementAPI = new ManagementAPI(this);
            StatAPI = new StatAPI(this);
        }

        public DataImportAPI DataImportAPI { get; private set; }
        public LogsAPI LogsAPI { get; private set; }
        public ManagementAPI ManagementAPI { get; private set; }
        public StatAPI StatAPI { get; private set; }

      
        
        
        
        
        #region Internal methods

        internal string CombineURL(string path)
        {
            return YandexMetrikaClient.HOST + path;
        }
        internal string CombineURL(string path, object queryParamsModel)
        {
            return MakeQueryParams(YandexMetrikaClient.HOST + path, queryParamsModel);
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
                throw new MetrikaRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
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
                throw new MetrikaRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
        }

        #endregion
    }

}
