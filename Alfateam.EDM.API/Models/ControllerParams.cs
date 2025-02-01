using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.EDM.API.Services;
using Alfateam.Gateways.Abstractions;

namespace Alfateam.EDM.API.Models
{
    public class ControllerParams
    {

        public ControllerParams(EDMDbContext db,
                                IDDbContext iddb,

                                AbsDBService dBService,
                                AbsFilesService filesService,
                                IWebHostEnvironment appEnv,
                                IMailGateway mailGateway,
                                ISMSGateway smsGateway,

                                CertCenterVerificationService certCenterVerificationService,
                                DocumentsService docService,
                                DocumentApprovalService docApprovalService,
                                UploadedFilesService uploadedFilesService)
        {
            DB = db;
            IDDB = iddb;

            DBService = dBService;
            FilesService = filesService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            SMSGateway = smsGateway;

            CertCenterVerificationService = certCenterVerificationService;
            DocService = docService;
            DocApprovalService = docApprovalService;
            UploadedFilesService = uploadedFilesService;
        }


        public EDMDbContext DB { get; set; }
        public IDDbContext IDDB { get; set; }


        public AbsDBService DBService { get; set; }
        public AbsFilesService FilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }




        public CertCenterVerificationService CertCenterVerificationService { get; set; }
        public DocumentsService DocService { get; set; }
        public DocumentApprovalService DocApprovalService { get; set; }
        public UploadedFilesService UploadedFilesService { get; set; }
    }
}
