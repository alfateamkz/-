using Alfateam.Abstractions;
using Alfateam.Database;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alfateam.Controllers
{
    public class MainController : AbsController
    {
        public MainController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("SetLocale")]
        public async Task SetLocale(int langId)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Language"))
            {
                HttpContext.Response.Cookies.Delete("Language");
            }
            HttpContext.Response.Cookies.Append("Language",langId.ToString());
        }
    }
}
