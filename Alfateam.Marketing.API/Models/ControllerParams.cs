using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.ServicesDBs;
using Alfateam.Gateways.Abstractions;

namespace Alfateam.Marketing.API.Models
{
    public class ControllerParams
    {
        public ControllerParams(MarketingDbContext db,
                                IDDbContext iddb,
                                SalesDbContext salesDb,
                                CurrencyRatesDbContext currencyRatesDb,

                                AbsDBService dBService,
                                AbsFilesService filesService,
                                IWebHostEnvironment appEnv,
                                IMailGateway mailGateway,
                                ISMSGateway smsGateway)
        {
            DB = db;
            IDDB = iddb;
            SalesDB = salesDb;
            CurrencyRatesDB = currencyRatesDb;

            DBService = dBService;
            FilesService = filesService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            SMSGateway = smsGateway;
        }


        public MarketingDbContext DB { get; set; }
        public IDDbContext IDDB { get; set; }
        public SalesDbContext SalesDB { get; set; }
        public CurrencyRatesDbContext CurrencyRatesDB { get; set; }


        public AbsDBService DBService { get; set; }
        public AbsFilesService FilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }
    }
}
