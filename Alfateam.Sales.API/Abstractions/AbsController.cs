using Alfateam.Core.Filters;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General.Subjects;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models.Security;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.Models.General.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [ErrorsFilter]
    [APIExceptionFilter]
    public abstract class AbsController : ControllerBase
    {
        public readonly SalesDbContext DB;
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

        //TODO: 1. проверка доступа к клиентам, заказам, воронкам и этапам воронок и другим сущностям при создании и апдейте
       

        public string Domain => Request.Headers["Domain"];
        public int? CompanyId => ParseIntValueFromHeader("CompanyId");






        public string AlfateamSessionID => Request.Headers["AlfateamSessionID"];
        public virtual Session? AlfateamSession => IDDB.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);

        public virtual Alfateam.Sales.Models.General.User? AuthorizedUser
        {
            get
            {
                var user = DB.Users.Include(o => o.Permissions)
                                   .FirstOrDefault(o => o.AlfateamID == this.AlfateamSession.User.Guid
                                                   && o.BusinessCompanyId == this.CompanyId
                                                   && !o.IsDeleted);
                return user;
            }
        }



        [NonAction]
        public void AddHistoryAction(string title, string description = null)
        {
            DBService.CreateEntity(DB.HistoryActions, new HistoryAction
            {
                Title = title,
                Description = description,
                CreatedById = this.AuthorizedUser.Id,
                BusinessCompanyId = (int)this.CompanyId,
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
