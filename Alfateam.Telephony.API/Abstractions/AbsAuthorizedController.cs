using Alfateam.ID.Models.Security;
using Alfateam.Telephony.API.Models;
using Alfateam.Telephony.Models.General.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Telephony.API.Abstractions
{
    public abstract class AbsAuthorizedController : AbsController
    {
        public AbsAuthorizedController(ControllerParams @params) : base(@params)
        {
        }

        public string AlfateamSessionID => Request.Headers["AlfateamSessionID"];
        public virtual Session? AlfateamSession => IDDB.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);

        public virtual Alfateam.Telephony.Models.General.User? AuthorizedUser
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
    }
}
