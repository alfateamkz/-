using Alfateam.Core.Exceptions;
using Alfateam.Core.Filters;
using Alfateam.Core.Helpers;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models;
using Alfateam.ID.Models.Enums;
using Alfateam.ID.Models.Security;
using Alfateam.ID.Models.Security.Verifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.ID.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [ErrorsFilter]
    [APIExceptionFilter]
    public abstract class AbsController : ControllerBase
    {
        public readonly IDDbContext DB;
        public readonly AbsDBService DBService;
        public readonly AlfateamIDCodesService CodesService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;

        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;
        public AbsController(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.DBService = @params.DBService;
            this.CodesService = @params.CodesService;

            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway; 
            this.SMSGateway = @params.SMSGateway;   
        }


        public virtual Session? Session => DB.Sessions.Include(o => o.User)
                                                      .FirstOrDefault(o => o.SessID == this.UserSessid);
        public string UserSessid => Request.Headers["Sessid"];


        protected Session CreateSession(User user)
        {
            var session = new Session()
            {
                UserId = user.Id,
            };

            DBService.CreateEntity(DB.Sessions, session);
            return session;
        }

 
    }
}
