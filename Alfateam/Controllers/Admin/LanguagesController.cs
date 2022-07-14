using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.Controllers.Admin
{
    [Authorize("Admin")]
    public class LanguagesController : AbsController
    {
        public LanguagesController(DatabaseContext db, IWebHostEnvironment appEnvironment) : base(db, appEnvironment)
        {
        }

        [HttpGet,Route("Admin/Languages")]
        public IActionResult Languages()
        {
            var languages = DB.Languages.ToList();
            return View(@"Views\Admin\Languages\Languages.cshtml", languages);
        }

        #region Добавление нового языка

        [HttpGet, Route("Admin/CreateLanguage")]
        public IActionResult CreateLanguage()
        {
            return View(@"Views\Admin\Languages\CreateLanguage.cshtml");
        }

        [HttpPost, Route("Admin/CreateLanguagePOST")]
        public async Task<IActionResult> CreateLanguagePOST(Language language)
        {
            language.IconPath = await SetAttachmentIfHas(language.IconPath);

            DB.Languages.Add(language);
            DB.SaveChanges();
            return RedirectToAction("Languages", "Languages");
        }
        #endregion



        #region Редактирование существующего языка

        [HttpGet, Route("Admin/UpdateLanguage")]
        public IActionResult UpdateLanguage(int id)
        {
            var lang = DB.Languages.FirstOrDefault(o => o.Id == id);
            return View(@"Views\Admin\Languages\UpdateLanguage.cshtml", lang);
        }
        [HttpPost, Route("Admin/UpdateLanguagePOST")]
        public async Task<IActionResult> UpdateLanguagePOST(Language language)
        {
            language.IconPath = await SetAttachmentIfHas(language.IconPath);

            DB.Languages.Update(language);
            DB.SaveChanges();
            return RedirectToAction("Languages", "Languages");
        }
        #endregion


        [HttpGet, Route("Admin/DeleteLanguage")]
        public IActionResult DeleteLanguage(int id)
        {
            var lang = DB.Languages.FirstOrDefault(o => o.Id == id);
            DB.Languages.Remove(lang);
            DB.SaveChanges();
            return RedirectToAction("Languages", "Languages");
        }
    }
}
