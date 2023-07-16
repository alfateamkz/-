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
    public class PortfolioCategoriesLocalizationsController : AbsController
    {
        public PortfolioCategoriesLocalizationsController(DatabaseContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        [Route("Localizations/PortfolioCategories")]
        public IActionResult PortfolioCategories()
        {
            var posts = DB.PortfolioCategories
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .ToList();
            posts.Reverse();

            var vm = new LocalizationListVM<PortfolioCategory>
            {
                Items = posts,
                CurrentLanguage = GetCurrentLanguage()
            };
            return View(@"Views\Admin\Localization\Items\PortfolioCategories\PortfolioCategories.cshtml", vm);
        }






        [Route("Localizations/CreatePortfolioCategoryLocalization")]
        public IActionResult CreatePortfolioCategoryLocalization(int id)
        {
            var vm = new LocalizationVM<PortfolioCategoryLocalization>
            {
                Id = id,
            };
            return View(@"Views\Admin\Localization\Items\PortfolioCategories\CreateLocalization.cshtml", vm);
        }
        [Route("Localizations/CreatePortfolioCategoryLocalizationPOST"), HttpPost]
        public async Task<IActionResult> CreatePortfolioCategoryLocalizationPOST([FromForm] LocalizationVM<PortfolioCategoryLocalization> vm)
        {
            vm.Localization.Language = GetCurrentLanguage();

            var option = DB.PortfolioCategories
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == vm.Id);
            option.Localizations.Add(vm.Localization);

            DB.PortfolioCategories.Update(option);
            DB.SaveChanges();
            return RedirectToAction("PortfolioCategories", "PortfolioCategoriesLocalizations");
        }





        [Route("Localizations/UpdatePortfolioCategoryLocalization")]
        public IActionResult UpdatePortfolioCategoryLocalization(int id)
        {
            var option = DB.PortfolioCategories
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == id);
            var lang = GetCurrentLanguage();

            var vm = new LocalizationVM<PortfolioCategoryLocalization>
            {
                Id = id,
                Localization = option.Localizations.FirstOrDefault(o => o.LanguageId == lang.Id)
            };
            return View(@"Views\Admin\Localization\Items\PortfolioCategories\UpdateLocalization.cshtml", vm);
        }
        [Route("Localizations/UpdatePortfolioCategoryLocalizationPOST"), HttpPost]
        public async Task<IActionResult> UpdatePortfolioCategoryLocalizationPOST([FromForm] LocalizationVM<PortfolioCategoryLocalization> vm)
        {
            DB.PortfolioCategoryLocalizations.Update(vm.Localization);
            DB.SaveChanges();
            return RedirectToAction("PortfolioCategories", "PortfolioCategoriesLocalizations");
        }

    }
}
