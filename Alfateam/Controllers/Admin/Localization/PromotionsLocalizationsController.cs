using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models;
using Alfateam.Database.Models.Localizations;
using Alfateam.Database.Models.Portfolios;
using Alfateam.Database.Models.Promotions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Triggero.Web.ViewModels.Localization;

namespace Triggero.Web.Controllers.Localization
{
    [Authorize]
    public class PromotionsLocalizationsController : AbsController
    {
        public PromotionsLocalizationsController(DatabaseContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        [Route("Localizations/Promotions")]
        public IActionResult Promotions()
        {
            var posts = DB.Promotions
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .ToList();
            posts.Reverse();

            var vm = new LocalizationListVM<Promotion>
            {
                Items = posts,
                CurrentLanguage = GetCurrentLanguage()
            };
            return View(@"Views\Admin\Localization\Items\Promotions\Promotions.cshtml", vm);
        }






        [Route("Localizations/CreatePromotionLocalization")]
        public IActionResult CreatePromotionLocalization(int id)
        {
            var vm = new LocalizationVM<PromotionLocalization>
            {
                Id = id,
            };
            return View(@"Views\Admin\Localization\Items\Promotions\CreateLocalization.cshtml", vm);
        }
        [Route("Localizations/CreatePromotionLocalizationPOST"), HttpPost]
        public async Task<IActionResult> CreatePromotionLocalizationPOST([FromForm] LocalizationVM<PromotionLocalization> vm)
        {
            vm.Localization.Language = GetCurrentLanguage();

            var option = DB.Promotions
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == vm.Id);
            option.Localizations.Add(vm.Localization);

            DB.Promotions.Update(option);
            DB.SaveChanges();
            return RedirectToAction("Promotions", "PromotionsLocalizations");
        }





        [Route("Localizations/UpdatePromotionLocalization")]
        public IActionResult UpdatePromotionLocalization(int id)
        {
            var option = DB.Promotions
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == id);
            var lang = GetCurrentLanguage();

            var vm = new LocalizationVM<PromotionLocalization>
            {
                Id = id,
                Localization = option.Localizations.FirstOrDefault(o => o.LanguageId == lang.Id)
            };
            return View(@"Views\Admin\Localization\Items\Promotions\UpdateLocalization.cshtml", vm);
        }
        [Route("Localizations/UpdatePromotionLocalizationPOST"), HttpPost]
        public async Task<IActionResult> UpdatePromotionLocalizationPOST([FromForm] LocalizationVM<PromotionLocalization> vm)
        {
            DB.PromotionLocalizations.Update(vm.Localization);
            DB.SaveChanges();
            return RedirectToAction("Promotions", "PromotionsLocalizations");
        }

    }
}
