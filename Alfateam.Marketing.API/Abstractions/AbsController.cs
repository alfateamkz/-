using Alfateam.Core.Filters;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.ServicesDBs;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models.Security;
using Alfateam.Marketing.API.Models;
using Alfateam.Marketing.Models.General.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Marketing.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [ErrorsFilter]
    [APIExceptionFilter]
    public class AbsController : ControllerBase
    {
        public readonly MarketingDbContext DB;
        public readonly IDDbContext IDDB;
        public readonly SalesDbContext SalesDB;
        public readonly CurrencyRatesDbContext CurrencyRatesDB;


        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;

        public AbsController(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.IDDB = @params.IDDB;
            this.SalesDB = @params.SalesDB;
            this.CurrencyRatesDB = @params.CurrencyRatesDB;


            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway;
            this.SMSGateway = @params.SMSGateway;

        }

        public string AlfateamSessionID => Request.Headers["AlfateamSessionID"];
        public virtual Session? AlfateamSession => IDDB.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);
        public virtual Alfateam.Marketing.Models.General.User? AuthorizedUser
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






        public string Domain => Request.Headers["Domain"];
        public int? BusinessId
        {
            get
            {
                var business = DB.Businesses.FirstOrDefault(o => o.Domain == this.Domain && !o.IsDeleted);
                return business?.Id;
            }
        }

        public int? CompanyId => ParseIntValueFromHeader("CompanyId");



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
