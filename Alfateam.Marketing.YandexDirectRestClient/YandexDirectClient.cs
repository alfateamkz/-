using Alfateam.Marketing.YandexDirectRestClient.Exceptions;
using Alfateam.Marketing.YandexDirectRestClient.Modules;
using Newtonsoft.Json;
using RestSharp;

namespace Alfateam.Marketing.YandexDirectRestClient
{
    public class YandexDirectClient
    {
        public const string HOST = "https://api.direct.yandex.com/json/v501/";


        public readonly string AccessToken;
        public readonly RestClient RestClient;
        public YandexDirectClient(string accessToken)
        {
            AccessToken = accessToken;
            RestClient = new RestClient();

            AdExtensions = new AdExtensionsModule(this);
            AdGroups = new AdGroupsModule(this);
            AdImages = new AdImagesModule(this);
            Ads = new AdsModule(this);
            AdVideos = new AdVideosModule(this);
            AgencyClients = new AgencyClientsModule(this);
            AudienceTargets = new AudienceTargetsModule(this);
            BidModifiers = new BidModifiersModule(this);
            Bids = new BidsModule(this);
            Businesses = new BusinessesModule(this);
            Campaigns = new CampaignsModule(this);
            Changes = new ChangesModule(this);
            Clients = new ClientsModule(this);
            Creatives = new CreativesModule(this);
            Dictionaries = new DictionariesModule(this);
            DynamicFeedAdTargets = new DynamicFeedAdTargetsModule(this);
            DynamicTextAdTargets = new DynamicTextAdTargetsModule(this);
            Feeds = new FeedsModule(this);
            KeywordBids = new KeywordBidsModule(this);
            Keywords = new KeywordsModule(this);
            KeywordsResearch = new KeywordsResearchModule(this);
            Leads = new LeadsModule(this);
            NegativeKeywordSharedSets = new NegativeKeywordSharedSetsModule(this);
            RetargetingLists = new RetargetingListsModule(this);
            Sitelinks = new SitelinksModule(this);
            SmartAdTargets = new SmartAdTargetsModule(this);
            Strategies = new StrategiesModule(this);
            TurboPages = new TurboPagesModule(this);
            VCards = new VCardsModule(this);    
        }

        public AdExtensionsModule AdExtensions { get; private set; }
        public AdGroupsModule AdGroups { get; private set; }
        public AdImagesModule AdImages { get; private set; }
        public AdsModule Ads { get; private set; }
        public AdVideosModule AdVideos { get; private set; }
        public AgencyClientsModule AgencyClients { get; private set; }
        public AudienceTargetsModule AudienceTargets { get; private set; }
        public BidModifiersModule BidModifiers { get; private set; }
        public BidsModule Bids { get; private set; }
        public BusinessesModule Businesses { get; private set; }
        public CampaignsModule Campaigns { get; private set; }
        public ChangesModule Changes { get; private set; }
        public ClientsModule Clients { get; private set; }
        public CreativesModule Creatives { get; private set; }
        public DictionariesModule Dictionaries { get; private set; }
        public DynamicFeedAdTargetsModule DynamicFeedAdTargets { get; private set; }
        public DynamicTextAdTargetsModule DynamicTextAdTargets { get; private set; }
        public FeedsModule Feeds { get; private set; }
        public KeywordBidsModule KeywordBids { get; private set; }
        public KeywordsModule Keywords { get; private set; }
        public KeywordsResearchModule KeywordsResearch { get; private set; }
        public LeadsModule Leads { get; private set; }
        public NegativeKeywordSharedSetsModule NegativeKeywordSharedSets { get; private set; }
        public RetargetingListsModule RetargetingLists { get; private set; }
        public SitelinksModule Sitelinks { get; private set; }
        public SmartAdTargetsModule SmartAdTargets { get; private set; }
        public StrategiesModule Strategies { get; private set; }
        public TurboPagesModule TurboPages { get; private set; }
        public VCardsModule VCards { get; private set; }




        #region Internal methods

        internal string CombineURL(string path)
        {
            return YandexDirectClient.HOST + path;
        }
        internal string CombineURL(string path, object queryParamsModel)
        {
            return MakeQueryParams(YandexDirectClient.HOST + path, queryParamsModel);
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
                throw new DirectRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
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
            req = req.AddHeader("Authorization", AccessToken);

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
                throw new DirectRestClientException((int)response.StatusCode, JsonConvert.DeserializeObject(response.Content));
            }
        }

        #endregion
    }
}
