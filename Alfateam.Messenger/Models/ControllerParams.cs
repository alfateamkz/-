using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.Messenger.API.Services;

namespace Alfateam.Messenger.API.Models
{
    public class ControllerParams
    {
        public ControllerParams(MessengerDbContext db,
                                IDDbContext iddb,

                                AbsDBService dBService,
                                AbsFilesService filesService,
                                IWebHostEnvironment appEnv,
                                IMailGateway mailGateway,
                                ISMSGateway smsGateway,

                                ChatMiscService chatMisc)
        {
            DB = db;
            IDDB = iddb;

            DBService = dBService;
            FilesService = filesService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            SMSGateway = smsGateway;

            ChatMiscService = chatMisc;
        }


        public MessengerDbContext DB { get; set; }
        public IDDbContext IDDB { get; set; }



        public AbsDBService DBService { get; set; }
        public AbsFilesService FilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }



        public ChatMiscService ChatMiscService  { get; set; }
    }
}
