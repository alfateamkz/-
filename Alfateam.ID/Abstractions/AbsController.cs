using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.ID.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AbsController : ControllerBase
    {
        public readonly IDDbContext DB;
        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;
        public AbsController(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway; 
            this.SMSGateway = @params.SMSGateway;   
        }
    }
}
