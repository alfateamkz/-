using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;

namespace Alfateam.EDM.API.Models
{
    public class ControllerParams
    {
        public EDMDbContext DB { get; set; }
        public AbsDBService DBService { get; set; }
        public AbsFilesService FilesService { get; set; }
        public IWebHostEnvironment AppEnvironment { get; set; }
        public IMailGateway MailGateway { get; set; }
        public ISMSGateway SMSGateway { get; set; }
    }
}
