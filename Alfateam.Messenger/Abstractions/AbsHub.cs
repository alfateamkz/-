using Alfateam.Core.Exceptions;
using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.Gateways.Abstractions;
using Alfateam.ID.Models.Security;
using Alfateam.Messenger.API.Helpers;
using Alfateam.Messenger.API.Models;
using Alfateam.Messenger.API.Services;
using Alfateam.Messenger.Lib.Abstractions;
using Alfateam.Messenger.Models.Abstractions;
using Alfateam.Messenger.Models.General;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Messenger.API.Abstractions
{
    public abstract class AbsHub : Hub
    {
        public readonly MessengerDbContext DB;
        public readonly IDDbContext IDDB;

        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;


        public readonly ChatMiscService ChatMiscService;
        public readonly AlfateamMessengerService AlfateamMessengerService;
        public AbsHub(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.IDDB = @params.IDDB;

            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway;
            this.SMSGateway = @params.SMSGateway;

            this.ChatMiscService = @params.ChatMiscService;
            this.AlfateamMessengerService = @params.AlfateamMessengerService;
        }

        #region Omnichannel messenger headers and props

        public int? AccountId => ParseIntValueFromHeader("AccountId");
        public Account? Account => DB.Accounts.FirstOrDefault(o => o.Id == AccountId && !o.IsDeleted && o.CompanyWorkSpaceId == this.WorkspaceID);
        public AbsMessenger? Messenger => AccountsPool.GetOrCreateMessenger(Account);
       
        #endregion

        #region Ext messenger headers and props
        public int? ExtMessengerUserId => ParseIntValueFromHeader("ExtMessengerUserId");
        public string? ExtMessengerSecret => Context.GetHttpContext().Request.Headers["ExtMessengerSecret"];

        #endregion

        #region Alfateam ID User headers and props
        public string AlfateamSessionID => Context.GetHttpContext().Request.Headers["AlfateamSessionID"];
        public virtual Session? AlfateamSession => IDDB.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);


        public virtual User? AuthorizedUser
        {
            get
            {
                var user = DB.Users.Include(o => o.Permissions)
                                   .Include(o => o.AllowedAccountsAccess).ThenInclude(o => o.AllowedAccounts)
                                   .FirstOrDefault(o => o.AlfateamID == this.AlfateamSession.User.Guid
                                                      && o.CompanyWorkSpaceId == this.Workspace.Id
                                                      && !o.IsDeleted);
                return user;
            }
        }

        #endregion



        public string Domain => Context.GetHttpContext().Request.Headers["Domain"];
        public int? BusinessId
        {
            get
            {
                var business = DB.Businesses.FirstOrDefault(o => o.Domain == this.Domain && !o.IsDeleted);
                return business?.Id;
            }
        }


        public int? WorkspaceID => ParseIntValueFromHeader("WorkspaceID");
        public virtual CompanyWorkSpace? Workspace
        {
            get
            {
                var workspace = DB.CompanyWorkSpaces.FirstOrDefault(o => o.Id == this.WorkspaceID && !o.IsDeleted);
                if (workspace == null)
                {
                    throw new Exception404("Рабочее пространство с данным ID не найдено");
                }
                else if (workspace.BusinessId != this.BusinessId)
                {
                    throw new Exception403("Данное рабочее пространство не принадлежит текущему бизнесу");
                }
                return workspace;
            }
        }



        protected void ThrowIfNull(object val, string message = "Сущность с данным id не найдена")
        {
            if (val == null)
            {
                throw new Exception404(message);
            }
        }
        protected int? ParseIntValueFromHeader(string key)
        {
            int? id = null;

            if (Context.GetHttpContext().Request.Headers.ContainsKey(key))
            {
                var str = Context.GetHttpContext().Request.Headers[key].ToString();
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
