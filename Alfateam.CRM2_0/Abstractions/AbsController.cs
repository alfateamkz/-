using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Security;
using Alfateam.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AbsController : ControllerBase
    {
        internal CRMDBContext DB { get; set; }
        internal IWebHostEnvironment AppEnvironment { get; set; }



        protected string UserSessid => Request.Headers["Sessid"];


        public AbsController(ControllerParams @params)
        {
            DB = @params.DB;
            AppEnvironment = @params.AppEnvironment;
        }

        [NonAction]
        public User? GetAuthorizedUser()
        {
            if (string.IsNullOrWhiteSpace(UserSessid))
            {
                return null;
            }

            var session = DB.Sessions.Include(o => o.User).ThenInclude(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
                                     .FirstOrDefault(o => o.SessID == UserSessid);
            if (!CheckSession(session))
            {
                return null;
            }

            return session.User;
        }

        protected bool CheckSession(Session session)
        {
            if(session == null) return false;
            if(session.IsExpired) return false;
            if(session.IsDeactivated )return false;

            return true;
        }
    }
}
