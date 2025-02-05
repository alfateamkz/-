using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.Gateways.Abstractions;

namespace Alfateam.ForPubilcWebsites.API.Models
{
    public class ControllerParams
    {
        public ControllerParams(IDDbContext iddb,
                               AdmininstrationDbContext admininstrationDb,

                               AbsDBService dBService,
                               AbsFilesService filesService,
                               UploadedFilesService uploadedFilesService,
                               IWebHostEnvironment appEnv,
                               IMailGateway mailGateway,
                               ISMSGateway smsGateway)
        {
            IdDb = iddb;
            AdmininstrationDb = admininstrationDb;

            DBService = dBService;
            FilesService = filesService;
            UploadedFilesService = uploadedFilesService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            SMSGateway = smsGateway;
        }


        public IDDbContext IdDb { get; set; }
        public AdmininstrationDbContext AdmininstrationDb { get; set; }



        public AbsDBService DBService { get; set; }
        public AbsFilesService FilesService { get; set; }
        public UploadedFilesService UploadedFilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }
    }
}
