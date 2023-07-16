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
    public class PartnersLocalizationsController : AbsController
    {
        public PartnersLocalizationsController(DatabaseContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        [Route("Localizations/Partners")]
        public IActionResult Partners()
        {
            var posts = DB.Partners
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .ToList();
            posts.Reverse();

            var vm = new LocalizationListVM<Partner>
            {
                Items = posts,
                CurrentLanguage = GetCurrentLanguage()
            };
            return View(@"Views\Admin\Localization\Items\Partners\Partners.cshtml", vm);
        }






        [Route("Localizations/CreatePartnerLocalization")]
        public IActionResult CreatePartnerLocalization(int id)
        {
            var vm = new LocalizationVM<PartnerLocalization>
            {
                Id = id,
            };
            return View(@"Views\Admin\Localization\Items\Partners\CreateLocalization.cshtml", vm);
        }
        [Route("Localizations/CreatePartnerLocalizationPOST"), HttpPost]
        public async Task<IActionResult> CreatePartnerLocalizationPOST([FromForm] LocalizationVM<PartnerLocalization> vm)
        {
            vm.Localization.Language = GetCurrentLanguage();

            var option = DB.Partners
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == vm.Id);
            option.Localizations.Add(vm.Localization);

            DB.Partners.Update(option);
            DB.SaveChanges();
            return RedirectToAction("Partners", "PartnersLocalizations");
        }





        [Route("Localizations/UpdatePartnerLocalization")]
        public IActionResult UpdatePartnerLocalization(int id)
        {
            var option = DB.Partners
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == id);
            var lang = GetCurrentLanguage();

            var vm = new LocalizationVM<PartnerLocalization>
            {
                Id = id,
                Localization = option.Localizations.FirstOrDefault(o => o.LanguageId == lang.Id)
            };
            return View(@"Views\Admin\Localization\Items\Partners\UpdateLocalization.cshtml", vm);
        }
        [Route("Localizations/UpdatePartnerLocalizationPOST"), HttpPost]
        public async Task<IActionResult> UpdatePartnerLocalizationPOST([FromForm] LocalizationVM<PartnerLocalization> vm)
        {
            DB.PartnerLocalizations.Update(vm.Localization);
            DB.SaveChanges();
            return RedirectToAction("Partners", "PartnersLocalizations");
        }

    }
}
