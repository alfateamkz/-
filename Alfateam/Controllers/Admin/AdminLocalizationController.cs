using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Controllers.Admin
{
    [Authorize("Admin")]
    public class AdminLocalizationController : AbsController
    {
        public AdminLocalizationController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet, Route("Admin/SelectLanguage")]
        public IActionResult SelectLanguage()
        {
            var languages = DB.Languages.ToList();
            return View(@"Views\Admin\Localization\SelectLanguage.cshtml", languages);
        }
        [HttpGet, Route("Admin/LocalizationMainPage")]
        public IActionResult LocalizationMainPage(int langId = 1)
        {
            if (Request.Cookies.ContainsKey("Language_HUI"))
            {
                Response.Cookies.Delete("Language_HUI");
            }
            Response.Cookies.Append("Language_HUI", langId.ToString());

            var lang = DB.Languages.FirstOrDefault(o => o.Id == langId);

            return View(@"Views\Admin\Localization\MainPage.cshtml", lang);
        }









        [HttpGet, Route("GetLanguageCookie")]
        public async Task<Language> GetLanguageCookie()
        {
            if (HttpContext.Request.Cookies.ContainsKey("Language_HUI"))
            {
                int id = Convert.ToInt32(HttpContext.Request.Cookies["Language_HUI"]);
                return DB.Languages.FirstOrDefault(o => o.Id == id);
            }
            return null;
        }
        [HttpGet, Route("SetLanguageCookie")]
        public async Task SetLanguageCookie(int langId)
        {
            if (HttpContext.Request.Cookies.ContainsKey("Language_HUI"))
            {
                HttpContext.Response.Cookies.Delete("Language_HUI");
            }
            HttpContext.Response.Cookies.Append("Language_HUI", langId.ToString());
        }
    }
}
