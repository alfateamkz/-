using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models.General;
using Alfateam.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alfateam.Controllers
{
    public class AuthController : AbsController
    {
        public AuthController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [Route("HasUser")]
        public IActionResult HasUser(string email,string password)
        {
            return new JsonResult(DB.Users.FirstOrDefault(o => o.Email == email && o.Password == password) != null);
        }




        [HttpPost]
        public async Task<IActionResult> Auth([FromForm] LoginViewModel model)
        {
            var found = DB.Users.FirstOrDefault(o => o.Email == model.Email && o.Password == model.Password);
            if (found != null)
            {
                var principal = await MakeAuth(found);

                return RedirectToAction("Orders", "Orders");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task<ClaimsPrincipal> MakeAuth(UserModel user)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // создаем один claim
            var claims = new List<Claim>
            {
                 new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                 new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole.ToString())
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            var principal = new ClaimsPrincipal(id);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return principal;
        }
    }

}
