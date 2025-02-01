using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.DB.Services;
using Alfateam.EDM.API.Filters;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.API.Services;
using Alfateam.EDM.Models.Abstractions;
using Alfateam.EDM.Models.General;
using Alfateam.EDM.Models.General.Security;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.EDM.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [AlfateamAPIKeyFilter]
    public abstract class AbsController : ControllerBase
    {
        public readonly EDMDbContext DB;
        public readonly IDDbContext IDDB;

        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;


        public readonly CertCenterVerificationService CertCenterVerificationService;
        public readonly DocumentsService DocService;
        public readonly DocumentApprovalService DocApprovalService;
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


            this.CertCenterVerificationService = @params.CertCenterVerificationService;
            this.DocService = @params.DocService;
            this.DocApprovalService = @params.DocApprovalService;
            this.UploadedFilesService = @params.UploadedFilesService;
        }


        public string API_KEY => Request.Headers["API_KEY"];
        public string Domain => Request.Headers["Domain"];
        public int? EDMSubjectId => ParseIntValueFromHeader("EDMSubjectId");
        public string AlfateamSessionID => Request.Headers["AlfateamSessionID"];


        public virtual Session? AlfateamSession => IDDB.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);
        
      

        public int? BusinessId
        {
            get
            {
                var business = DB.Businesses.FirstOrDefault(o => o.Domain == this.Domain && !o.IsDeleted);
                return business?.Id;
            }
        }

        public EDMSubject EDMSubject
        {
            get
            {
                var companies = DB.EDMSubjects.Where(o => !o.IsDeleted && o.BusinessId == this.BusinessId);
                return DBService.TryGetOne(companies, (int)this.EDMSubjectId);
            }
        }



        private int? ParseIntValueFromHeader(string key)
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
