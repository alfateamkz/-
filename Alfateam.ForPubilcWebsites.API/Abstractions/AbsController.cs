using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.ForPubilcWebsites.API.Models;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.ForPubilcWebsites.API.Abstractions
{
    public abstract class AbsController : ControllerBase
    {
        public readonly IDDbContext IdDb;
        public readonly AdmininstrationDbContext AdmininstrationDb;



        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly UploadedFilesService UploadedFilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;

        public AbsController(ControllerParams @params)
        {
            this.IdDb = @params.IdDb;
            this.AdmininstrationDb = @params.AdmininstrationDb;


            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.UploadedFilesService = @params.UploadedFilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway;
            this.SMSGateway = @params.SMSGateway;
        }


        public string? AlfateamSessionID => Request.Headers["AlfateamSessionID"];
        public virtual Session? AlfateamSession => IdDb.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);
        public virtual Alfateam.ID.Models.User? AlfateamUser => AlfateamSession?.User;
    }
}
