using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models.Localizations;
using Alfateam.Database.Models.Portfolios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Triggero.Web.ViewModels.Localization;

namespace Triggero.Web.Controllers.Localization
{
    [Authorize]
    public class PortfolioLocalizationsController : AbsController
    {
        public PortfolioLocalizationsController(DatabaseContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        [Route("Localizations/Portfolio")]
        public IActionResult Portfolio()
        {
            var posts = DB.Portfolios
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .ToList();
            posts.Reverse();

            var vm = new LocalizationListVM<Portfolio>
            {
                Items = posts,
                CurrentLanguage = GetCurrentLanguage()
            };
            return View(@"Views\Admin\Localization\Items\Portfolio\Portfolio.cshtml", vm);
        }






        [Route("Localizations/CreatePortfolioLocalization")]
        public IActionResult CreatePortfolioLocalization(int id)
        {
            var vm = new LocalizationVM<PortfolioLocalization>
            {
                Id = id,
            };
            return View(@"Views\Admin\Localization\Items\Portfolio\CreateLocalization.cshtml", vm);
        }
        [Route("Localizations/CreatePortfolioLocalizationPOST"), HttpPost]
        public async Task<IActionResult> CreatePortfolioLocalizationPOST([FromForm] LocalizationVM<PortfolioLocalization> vm)
        {
            vm.Localization.Language = GetCurrentLanguage();

            var option = DB.Portfolios
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == vm.Id);
            option.Localizations.Add(vm.Localization);

            DB.Portfolios.Update(option);
            DB.SaveChanges();
            return RedirectToAction("Portfolio", "PortfolioLocalizations");
        }





        [Route("Localizations/UpdatePortfolioLocalization")]
        public IActionResult UpdatePortfolioLocalization(int id)
        {
            var option = DB.Portfolios
                .Include(o => o.Localizations).ThenInclude(o => o.Language)
                .FirstOrDefault(o => o.Id == id);
            var lang = GetCurrentLanguage();

            var vm = new LocalizationVM<PortfolioLocalization>
            {
                Id = id,
                Localization = option.Localizations.FirstOrDefault(o => o.LanguageId == lang.Id)
            };
            return View(@"Views\Admin\Localization\Items\Portfolio\UpdateLocalization.cshtml", vm);
        }
        [Route("Localizations/UpdatePortfolioLocalizationPOST"), HttpPost]
        public async Task<IActionResult> UpdatePortfolioLocalizationPOST([FromForm] LocalizationVM<PortfolioLocalization> vm)
        {
            DB.PortfolioLocalizations.Update(vm.Localization);
            DB.SaveChanges();
            return RedirectToAction("Portfolio", "PortfolioLocalizations");
        }

    }
}
