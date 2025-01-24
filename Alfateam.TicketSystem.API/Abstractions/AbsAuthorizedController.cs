using Alfateam.ID.Models.Security;
using Alfateam.TicketSystem.API.Filters;
using Alfateam.TicketSystem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.TicketSystem.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    [AuthorizedUser]
    [CheckCompanyAccess]
    public class AbsAuthorizedController : AbsController
    {
        public AbsAuthorizedController(ControllerParams @params) : base(@params)
        {
        }


        public string AlfateamSessionID => Request.Headers["AlfateamSessionID"];
        public virtual Session? AlfateamSession => IDDB.Sessions.Include(o => o.User)
                                                                .FirstOrDefault(o => o.SessID == this.AlfateamSessionID);

        public virtual Alfateam.TicketSystem.Models.General.User? AuthorizedUser
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
    }
}
