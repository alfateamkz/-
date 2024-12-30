using Alfateam.Marketing.YandexWebmasterRestClient.Exceptions;
using Alfateam.Marketing.YandexWebmasterRestClient.Models;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.Diagnostics;
using Alfateam.Marketing.YandexWebmasterRestClient.Models.GetHostById;
using Alfateam.Marketing.YandexWebmasterRestClient.Modules;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;

namespace Alfateam.Marketing.YandexWebmasterRestClient
{
    public class YandexWebmasterClient
    {
        public const string HOST = "https://api.webmaster.yandex.net/v4";
        public readonly RestClient RestClient;

        public string OAUTH_TOKEN;
        public long UserID;
        public YandexWebmasterClient()
        {
            RestClient = new RestClient();

            ExternalLinks = new ExternalLinksModule(this);
            Feeds = new FeedsModule(this);
            HostSearchQueries = new HostSearchQueriesModule(this);
            Hosts = new HostsModule(this);
            Indexing = new IndexingModule(this);
            InSearch = new InSearchModule(this);
            InternalLinks = new InternalLinksModule(this);
            Recrawl = new RecrawlModule(this);
            Sitemaps = new SitemapsModule(this);
            SiteQuality = new SiteQualityModule(this);
            Verification = new VerificationModule(this);
        }

        public YandexWebmasterClient(string oauthToken) : base()
        {
            OAUTH_TOKEN = oauthToken;
        }


        public ExternalLinksModule ExternalLinks { get; private set; }
        public FeedsModule Feeds { get; private set; }
        public HostSearchQueriesModule HostSearchQueries { get; private set; }
        public HostsModule Hosts { get; private set; }
        public IndexingModule Indexing { get; private set; }
        public InSearchModule InSearch { get; private set; }
        public InternalLinksModule InternalLinks { get; private set; }
        public RecrawlModule Recrawl { get; private set; }
        public SitemapsModule Sitemaps { get; private set; }
        public SiteQualityModule SiteQuality { get; private set; }
        public VerificationModule Verification { get; private set; }

        

        public async Task<User> User()
        {
            return await MakeRequestAndThrowIfNotSuccess<User>(CombineURL("/user"), Method.Get);
        }

        public async Task<Host> HostsId(int hostId)
        {
            return await MakeRequestAndThrowIfNotSuccess<Host>(CombineURL($"/user/{this.UserID}/hosts/{hostId}"), Method.Get);
        }

        public async Task<DiagnosticsResponse> HostDiagnosticsGet(int hostId)
        {
            return await MakeRequestAndThrowIfNotSuccess<DiagnosticsResponse>(CombineURL($"/user/{this.UserID}/hosts/{hostId}/diagnostics"), Method.Get);
        }


        #region Internal methods

        internal string CombineURL(string path)
        {
            return YandexWebmasterClient.HOST + path;
        }
        internal string CombineURL(string path, object queryParamsModel)
        {
            return MakeQueryParams(YandexWebmasterClient.HOST + path, queryParamsModel);
        }

        internal string MakeQueryParams(string url,object queryParamsModel)
        {
            string urlWithParams = url;

            var props = queryParamsModel.GetType().GetProperties();

            int counter = 1;
            foreach(var prop in props)
            {
                string paramName = prop.Name;
                if(prop.GetCustomAttributes(false).Any(o => o is JsonPropertyAttribute))
                {
                    var attr = prop.GetCustomAttributes(false).FirstOrDefault(o => o is JsonPropertyAttribute) as JsonPropertyAttribute;
                    paramName = attr.PropertyName;
                }

                if(counter == 1)
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
            if((int)response.StatusCode != expectedStatusCode)
            {
                throw new WebmasterRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
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
                throw new WebmasterRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
        }

        #endregion
    }
}
