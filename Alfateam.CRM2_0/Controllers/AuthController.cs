using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Core;
using Alfateam.CRM2_0.Models.General;
using Alfateam.CRM2_0.Models.Security;
using Alfateam.Website.API.Helpers;
using Alfateam.Website.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.CRM2_0.Controllers
{
    public class AuthController : AbsController
    {
        public AuthController(ControllerParams @params) : base(@params)
        {
        }

        [HttpGet, Route("Login")]
        public AuthResponseModel Login(string email, string password)
        {
            var res = new AuthResponseModel();


            var user = DB.Users.Include(o => o.RoleModel).ThenInclude(o => o.GivenRoles)
                               .Include(o => o.Country)
                               .FirstOrDefault(o => (o.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                                                  || o.Login == email)
                                && PasswordHelper.CheckEncryptedPassword(password, o.Password));

            if (user != null)
            {
                var session = new Session
                {
                    User = user,
                };
                DB.Sessions.Add(session);
                DB.SaveChanges();

                res.User = user;
                res.Sessid = session.SessID;
            }

            return res;
        }

      
    }
}
