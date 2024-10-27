using Alfateam.Core.Filters;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models.Security;
using Alfateam.Messenger.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Messenger.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [ErrorsFilter]
    [APIExceptionFilter]
    public abstract class AbsController : ControllerBase
    {
        public readonly MessengerDbContext DB;
        public readonly IDDbContext IDDB;
        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;

        public AbsController(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.IDDB = @params.IDDB;
            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway;
            this.SMSGateway = @params.SMSGateway;
        }

        public string AlfateamSessionID => Request.Headers["AlfateamSessionID"];
        public virtual Session? AlfateamSession => IDDB.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);
    }
}
