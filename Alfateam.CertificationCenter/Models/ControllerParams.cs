using Alfateam.CertificationCenter.API.Services;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.Gateways.Abstractions;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Alfateam.CertificationCenter.Models
{
    public class ControllerParams
    {
        public ControllerParams(CertCenterDbContext db,
                                IDDbContext idDb,
                                AlfateamIDCodesService codesService,
                                CancellationRequestsService cancellationRequestsService,

                                AbsDBService dBService,
                                AbsFilesService filesService,
                                IWebHostEnvironment appEnv,
                                IMailGateway mailGateway,
                                ISMSGateway smsGateway,

                                UploadedFilesService uploadedFilesService)
        {
            DB = db;
            IDDB = idDb;
            CodesService = codesService;
            CancellationRequestsService = cancellationRequestsService;

            DBService = dBService;
            FilesService = filesService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            SMSGateway = smsGateway;

            UploadedFilesService = uploadedFilesService;
        }


        public CertCenterDbContext DB { get; set; }
        public IDDbContext IDDB { get; set; }
        public AlfateamIDCodesService CodesService { get; set; }
        public CancellationRequestsService CancellationRequestsService { get; set; }



        public AbsDBService DBService { get; set; }
        public AbsFilesService FilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }



        public UploadedFilesService UploadedFilesService { get; set; }
    }
}

