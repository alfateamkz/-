using Alfateam.AdminPanelGeneral.API.Models;
using Alfateam.Core.Services;
using Alfateam.DB.ServicesDBs;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Alfateam.Administration.Models.General.Security;
using Alfateam.ID.Models.Security;
using Microsoft.EntityFrameworkCore;
using Alfateam.AdminPanelGeneral.API.Filters;
using Alfateam.DB.Services;

namespace Alfateam.AdminPanelGeneral.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [AuthorizedUser]
    public abstract class AbsController : ControllerBase
    {
        public readonly IDDbContext IdDb;
        public readonly AdmininstrationDbContext AdmininstrationDb;
        public readonly CertCenterDbContext CertCenterDb;


        public readonly SalesDbContext SalesDb;
        public readonly MarketingDbContext MarketingDb;
        public readonly TelephonyDbContext TelephonyDb;
        public readonly MessengerDbContext MessengerDb;
        public readonly EDMDbContext EDMDb;


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
            this.CertCenterDb = @params.CertCenterDb;

            this.SalesDb = @params.SalesDb;
            this.MarketingDb = @params.MarketingDb;
            this.TelephonyDb = @params.TelephonyDb;
            this.MessengerDb = @params.MessengerDb;
            this.EDMDb = @params.EDMDb;


            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.UploadedFilesService = @params.UploadedFilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway;
            this.SMSGateway = @params.SMSGateway;
        }


        public string AlfateamSessionID => Request.Headers["AlfateamSessionID"];
        public virtual Session? AlfateamSession => IdDb.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);
        public virtual Alfateam.Administration.Models.General.User? AuthorizedUser
        {
            get
            {
                var user = AdmininstrationDb.Users.Include(o => o.RoleModel)
                                                  .FirstOrDefault(o => o.AlfateamID == this.AlfateamSession.User.Guid && !o.IsDeleted);
                return user;
            }
        }



        [NonAction]
        public void AddHistoryAction(string title, string description = null)
        {
            DBService.CreateEntity(AdmininstrationDb.UserActions, new UserAction
            {
                Title = title,
                Description = description,
                UserId = this.AuthorizedUser.Id,
            });
        }



        protected int? ParseIntValueFromHeader(string key)
        {
            int? id = null;

            if (Request.Headers.ContainsKey(key))
            {
                var str = Request.Headers[key].ToString();
                if (str != null)
                {
                    int val = 0;
                    int.TryParse(str, out val);

                    if (val != 0)
                    {
                        id = val;
                    }
                }
            }

            return id;
        }
    }
}
