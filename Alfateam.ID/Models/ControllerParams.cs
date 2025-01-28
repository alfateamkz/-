using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.Gateways.Abstractions;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Alfateam.ID.Models
{
    public class ControllerParams
    {

        public ControllerParams(IDDbContext db,
                                AbsDBService dBService,
                                AlfateamIDCodesService codesService,

                                AbsFilesService filesService,
                                IWebHostEnvironment appEnv,
                                IMailGateway mailGateway,
                                ISMSGateway smsGateway)
        {
            DB = db;
            DBService = dBService;
            CodesService = codesService;

            FilesService = filesService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            SMSGateway = smsGateway;
        }


        public IDDbContext DB { get; set; }
        public AbsDBService DBService { get; set; }
        public AlfateamIDCodesService CodesService { get; set; }


        public AbsFilesService FilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }
    }
}
