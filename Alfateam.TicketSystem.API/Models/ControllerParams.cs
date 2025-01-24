using Alfateam.Core.Services;
using Alfateam.DB.ServicesDBs;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.TicketSystem.API.Services;

namespace Alfateam.TicketSystem.API.Models
{
    public class ControllerParams
    {
        public ControllerParams(TicketSystemDbContext db,
                                IDDbContext idDb,

                                AbsDBService dBService,
                                AbsFilesService filesService,
                                IWebHostEnvironment appEnv,
                                IMailGateway mailGateway,
                                ISMSGateway smsGateway,

                                UploadedFilesService uploadedFilesService)
        {
            DB = db;
            IDDB = idDb;

            DBService = dBService;
            FilesService = filesService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            SMSGateway = smsGateway;

            UploadedFilesService = uploadedFilesService;
        }


        public TicketSystemDbContext DB { get; set; }
        public IDDbContext IDDB { get; set; }


        public AbsDBService DBService { get; set; }
        public AbsFilesService FilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }



        public UploadedFilesService UploadedFilesService { get; set; }
    }
}
