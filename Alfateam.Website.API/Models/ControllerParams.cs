using Alfateam.DB;
using Alfateam.Gateways;
using Alfateam.Gateways.Abstractions;
using Alfateam.Website.API.Services.General;

namespace Alfateam.Website.API.Models
{
    public class ControllerParams
    {
        public WebsiteDBContext DB { get; set; }
        public DBService DbService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public FilesService FilesService { get; set; }


        public ControllerParams(WebsiteDBContext db, 
                                DBService dbService, 
                                IWebHostEnvironment appEnv,
                                IMailGateway mailGateway,
                                FilesService filesService)
        {
            DB = db;
            DbService = dbService;
            AppEnvironment = appEnv;
            MailGateway = mailGateway;
            FilesService = filesService;
        }
    }
}
