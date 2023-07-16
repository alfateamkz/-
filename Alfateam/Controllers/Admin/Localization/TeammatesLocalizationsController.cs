using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models;
using Alfateam.Database.Models.Localizations;
using Alfateam.Database.Models.Portfolios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Triggero.Web.ViewModels.Localization;

namespace Triggero.Web.Controllers.Localization
{
    [Authorize]
    public class TeammatesLocalizationsController : AbsController
    {
        public TeammatesLocalizationsController(DatabaseContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        [Route("Localizations/Teammates")]
        public IActionResult Teammates()
        {
            var posts = DB.Teammates
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .ToList();
            posts.Reverse();

            var vm = new LocalizationListVM<Teammate>
            {
                Items = posts,
                CurrentLanguage = GetCurrentLanguage()
            };
            return View(@"Views\Admin\Localization\Items\Teammates\Teammates.cshtml", vm);
        }






        [Route("Localizations/CreateTeammateLocalization")]
        public IActionResult CreateTeammateLocalization(int id)
        {
            var vm = new LocalizationVM<TeammateLocalization>
            {
                Id = id,
            };
            return View(@"Views\Admin\Localization\Items\Teammates\CreateLocalization.cshtml", vm);
        }
        [Route("Localizations/CreateTeammateLocalizationPOST"), HttpPost]
        public async Task<IActionResult> CreateTeammateLocalizationPOST([FromForm] LocalizationVM<TeammateLocalization> vm)
        {
            vm.Localization.Language = GetCurrentLanguage();

            var option = DB.Teammates
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == vm.Id);
            option.Localizations.Add(vm.Localization);

            DB.Teammates.Update(option);
            DB.SaveChanges();
            return RedirectToAction("Teammates", "TeammatesLocalizations");
        }





        [Route("Localizations/UpdateTeammateLocalization")]
        public IActionResult UpdateTeammateLocalization(int id)
        {
            var option = DB.Teammates
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == id);
            var lang = GetCurrentLanguage();

            var vm = new LocalizationVM<TeammateLocalization>
            {
                Id = id,
                Localization = option.Localizations.FirstOrDefault(o => o.LanguageId == lang.Id)
            };
            return View(@"Views\Admin\Localization\Items\Teammates\UpdateLocalization.cshtml", vm);
        }
        [Route("Localizations/UpdateTeammateLocalizationPOST"), HttpPost]
        public async Task<IActionResult> UpdateTeammateLocalizationPOST([FromForm] LocalizationVM<TeammateLocalization> vm)
        {
            DB.TeammateLocalizations.Update(vm.Localization);
            DB.SaveChanges();
            return RedirectToAction("Teammates", "TeammatesLocalizations");
        }

    }
}
