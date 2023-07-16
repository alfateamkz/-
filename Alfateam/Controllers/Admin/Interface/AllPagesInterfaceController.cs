using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models.Localizations.Texts;
using Alfateam.Database.Models.Localizations.Texts.OtherPages;
using Alfateam.Database.Models.Localizations.Texts.Popups;
using Alfateam.Enums.Localization;
using GamblingFactory.Admin.ViewModels.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Triggero.Web.Models.Localization;
using Triggero.Web.ViewModels.Localization;

namespace Triggero.Web.Controllers.Localization
{
    [Authorize("Admin")]
    public class AllPagesInterfaceController : AbsController
    {
        public AllPagesInterfaceController(DatabaseContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }

        [Route("Interface/AllPages")]
        public IActionResult AllPages()
        {
            var vm = new LocalizationInterfaceAllPagesVM();
            FillLocalizationInterfaceAllPagesVM(vm);

            return View(@"Views\Admin\Localization\Texts\MainPage.cshtml", vm);
        }
        [Route("Interface/AllPagesByLang")]
        public IActionResult AllPagesByLang()
        {
            var vm = new LocalizationInterfaceAllPagesVM();

            vm.LanguageId = GetCurrentAdminTagLanguage()?.Id;
            FillLocalizationInterfaceAllPagesVM(vm);

            return View(@"Views\Admin\Localization\Texts\MainPage.cshtml", vm);
        }


        [Route("Interface/GeneralTextInterfacePage")]
        public IActionResult GeneralTextInterfacePage(GeneralTextLocalizationType type,int langId = 1)
        {
            object model = null;

            switch (type)
            {
                case GeneralTextLocalizationType.CalculatorLocalization:
                    model = DB.CalculatorLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new CalculatorLocalization() { LanguageId = langId };
                    break;
                case GeneralTextLocalizationType.MapBlockLocalization:
                    model = DB.MapBlockLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new MapBlockLocalization() { LanguageId = langId };
                    break;
                case GeneralTextLocalizationType.MainPageLocalization:
                    model = DB.MainPageLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new MainPageLocalization() { LanguageId = langId };
                    break;
                case GeneralTextLocalizationType.SharedLocalization:
                    model = DB.SharedLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new SharedLocalization() { LanguageId = langId };
                    break;
                case GeneralTextLocalizationType.ErrorPagesLocalization:
                    model = DB.ErrorPagesLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new ErrorPagesLocalization() { LanguageId = langId };
                    break;

            }

            var vm = new LocalizationPageTranslationVM
            {
                EnumInterfaceTextType = type,
                Model = model,
                AspSaveAction = "GeneralTextPOST",
                LanguageId = langId
            };
            return View(@"Views\Admin\Localization\Texts\GeneratedPage.cshtml", vm);
        }


        [Route("Interface/OtherPagesInterfacePage")]
        public IActionResult OtherPagesInterfacePage(OtherPagesLocalizationType type, int langId = 1)
        {
            object model = null;

            switch (type)
            {
                case OtherPagesLocalizationType.PrivacyPageLocalization:
                    model = DB.PrivacyPageLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new PrivacyPageLocalization() { LanguageId = langId };
                    break;
                case OtherPagesLocalizationType.NewsPageLocalization:
                    model = DB.NewsPageLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new NewsPageLocalization() { LanguageId = langId };
                    break;
                case OtherPagesLocalizationType.ServicesPageLocalization:
                    model = DB.ServicesPageLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new ServicesPageLocalization() { LanguageId = langId };
                    break;
                case OtherPagesLocalizationType.PortfolioPageLocalization:
                    model = DB.PortfolioPageLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new PortfolioPageLocalization() { LanguageId = langId };
                    break;
            }

            var vm = new LocalizationPageTranslationVM
            {
                EnumInterfaceTextType = type,
                Model = model,
                AspSaveAction = "OtherPagesPOST",
                LanguageId = langId
            };
            return View(@"Views\Admin\Localization\Texts\GeneratedPage.cshtml", vm);
        }



        [Route("Interface/PopupsInterfacePage")]
        public IActionResult PopupsInterfacePage(PopupsLocalizationType type, int langId = 1)
        {
            object model = null;

            switch (type)
            {
                case PopupsLocalizationType.AcceptOrderPopupLocalization:
                    model = DB.AcceptOrderPopupLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new AcceptOrderPopupLocalization() { LanguageId = langId };
                    break;
                case PopupsLocalizationType.CallPopupLocalization:
                    model = DB.CallPopupLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new CallPopupLocalization() { LanguageId = langId };
                    break;
                case PopupsLocalizationType.ContactsPopupLocalization:
                    model = DB.ContactsPopupLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new ContactsPopupLocalization() { LanguageId = langId };
                    break;
                case PopupsLocalizationType.PortfolioPopupLocalization:
                    model = DB.PortfolioPopupLocalizations.FirstOrDefault(o => o.LanguageId == langId);
                    if (model is null) model = new PortfolioPopupLocalization() { LanguageId = langId };
                    break;
            }

            var vm = new LocalizationPageTranslationVM
            {
                EnumInterfaceTextType = type,
                Model = model,
                AspSaveAction = "PopupsPOST",
                LanguageId = langId
            };
            return View(@"Views\Admin\Localization\Texts\GeneratedPage.cshtml", vm);
        }



        private void FillLocalizationInterfaceAllPagesVM(LocalizationInterfaceAllPagesVM vm)
        {
            vm.Groups.Add(new LocalizationPageGroupItem("Главные текста", "GeneralTextInterfacePage")
            {
                Pages = new List<LocalizationPageItem>()
                {
                    new LocalizationPageItem(GeneralTextLocalizationType.CalculatorLocalization),
                    new LocalizationPageItem(GeneralTextLocalizationType.ErrorPagesLocalization),
                    new LocalizationPageItem(GeneralTextLocalizationType.MainPageLocalization),
                    new LocalizationPageItem(GeneralTextLocalizationType.MapBlockLocalization),
                    new LocalizationPageItem(GeneralTextLocalizationType.SharedLocalization),
                }
            });
            vm.Groups.Add(new LocalizationPageGroupItem("Другие текста", "OtherPagesInterfacePage")
            {
                Pages = new List<LocalizationPageItem>()
                {
                    new LocalizationPageItem(OtherPagesLocalizationType.NewsPageLocalization),
                    new LocalizationPageItem(OtherPagesLocalizationType.PortfolioPageLocalization),
                    new LocalizationPageItem(OtherPagesLocalizationType.PrivacyPageLocalization),
                    new LocalizationPageItem(OtherPagesLocalizationType.ServicesPageLocalization),
                }
            });
            vm.Groups.Add(new LocalizationPageGroupItem("Попапы", "PopupsInterfacePage")
            {
                Pages = new List<LocalizationPageItem>()
                {
                    new LocalizationPageItem(PopupsLocalizationType.AcceptOrderPopupLocalization),
                    new LocalizationPageItem(PopupsLocalizationType.CallPopupLocalization),
                    new LocalizationPageItem(PopupsLocalizationType.ContactsPopupLocalization),
                    new LocalizationPageItem(PopupsLocalizationType.PortfolioPopupLocalization),
                }
            });
        }

    }
}
