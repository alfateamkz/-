using Alfateam.Core.Filters;
using Alfateam.Core.Services;
using Alfateam.DB.ServicesDBs;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Alfateam.TicketSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using Alfateam.ID.Models.Security;
using Alfateam.TicketSystem.API.Filters;
using Alfateam.TicketSystem.API.Services;

namespace Alfateam.TicketSystem.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [ErrorsFilter]
    [APIExceptionFilter]
    [AlfateamAPIKeyFilter]
    public abstract class AbsController : ControllerBase
    {
        public readonly TicketSystemDbContext DB;
        public readonly IDDbContext IDDB;

        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;

        public readonly UploadedFilesService UploadedFilesService;
        public AbsController(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.IDDB = @params.IDDB;

            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway;
            this.SMSGateway = @params.SMSGateway;

            this.UploadedFilesService = @params.UploadedFilesService;   
        }



        public string API_KEY => Request.Headers["API_KEY"];
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
