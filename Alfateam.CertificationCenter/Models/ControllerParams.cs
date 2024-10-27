using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;

namespace Alfateam.CertificationCenter.Models
{
    public class ControllerParams
    {
        public ControllerParams(CertCenterDbContext db,
                                IDDbContext idDb,
                                AbsDBService dBService,
                                AbsFilesService filesService,
                                IWebHostEnvironment appEnv,
                                IMailGateway mailGateway,
                                ISMSGateway smsGateway)
        {
            DB = db;
            IDDB = idDb;
            DBService = dBService;
            FilesService = filesService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            SMSGateway = smsGateway;
        }


        public CertCenterDbContext DB { get; set; }
        public IDDbContext IDDB { get; set; }
        public AbsDBService DBService { get; set; }
        public AbsFilesService FilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }
    }
}

