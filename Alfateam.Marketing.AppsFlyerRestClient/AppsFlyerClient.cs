using Alfateam.Marketing.AppsFlyerRestClient.APIs;

namespace Alfateam.Marketing.AppsFlyerRestClient
{
    public class AppsFlyerClient
    {

        public const string HOST = "https://hq1.appsflyer.com/api/";



        public readonly string Token;
        public string AppId { get; set; }
        public AppsFlyerClient(string token, string appId)
        {
            Token = token;
            AppId = appId;

            AnalyticsAPI = new AnalyticsAPI(this);
            AudiencesAPI = new AudiencesAPI(this);
            MarketplaceAPI = new MarketplaceAPI(this);
            MeasurementsAPI = new MeasurementsAPI(this);
            OnelinkAPI = new OnelinkAPI(this);
            RawDataReportAPI = new RawDataReportAPI(this);
            ROIAPI = new ROIAPI(this);
            SKANAPI = new SKANAPI(this);
        }



        public AnalyticsAPI AnalyticsAPI { get; private set; }
        public AudiencesAPI AudiencesAPI { get; private set; }
        public MarketplaceAPI MarketplaceAPI { get; private set; }
        public MeasurementsAPI MeasurementsAPI { get; private set; }
        public OnelinkAPI OnelinkAPI { get; private set; }
        public RawDataReportAPI RawDataReportAPI { get; private set; }
        public ROIAPI ROIAPI { get; private set; }
        public SKANAPI SKANAPI { get; private set; }
    }
}
