﻿using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.EDM.API.Models;
using Alfateam.EDM.API.Models.DTO.General;
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
    public abstract class AbsController : ControllerBase
    {
        public readonly EDMDbContext DB;
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


        public string Domain => Request.Headers["Domain"];
        public int? CompanyId => ParseIntValueFromHeader("CompanyId");
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
