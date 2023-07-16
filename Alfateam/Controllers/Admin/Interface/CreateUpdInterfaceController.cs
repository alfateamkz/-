using Alfateam.Abstractions;
using Alfateam.Database;
using Alfateam.Database.Models.Localizations.Texts;
using Alfateam.Database.Models.Localizations.Texts.OtherPages;
using Alfateam.Database.Models.Localizations.Texts.Popups;
using Alfateam.Enums.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Dynamic;

namespace Triggero.Web.Controllers.Localization
{

    /// <summary>
    /// Эта хуйня работает так
    /// К методу обращаемся. Если локализация с id == 0, то создаем локализацию
    /// Если нет, то делаем апдейт.
    /// Универсальная хуйня, хуле
    /// </summary>
    [Authorize("Admin")]
    public class CreateUpdInterfaceController : AbsController
    {
        public CreateUpdInterfaceController(DatabaseContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }


        [Route("Interface/GeneralTextPOST"), HttpPost]
        public async Task<IActionResult> GeneralTextPOST(GeneralTextLocalizationType type)
        {
            JToken item = (JToken)GenerateObjectFromForm();

            switch (type)
            {
                case GeneralTextLocalizationType.CalculatorLocalization:
                    DB.CalculatorLocalizations.Update(item.ToObject<CalculatorLocalization>());
                    break;
                case GeneralTextLocalizationType.ErrorPagesLocalization:
                    DB.ErrorPagesLocalizations.Update(item.ToObject<ErrorPagesLocalization>());
                    break;
                case GeneralTextLocalizationType.MainPageLocalization:
                    DB.MainPageLocalizations.Update(item.ToObject<MainPageLocalization>());
                    break;
                case GeneralTextLocalizationType.MapBlockLocalization:
                    DB.MapBlockLocalizations.Update(item.ToObject<MapBlockLocalization>());
                    break;
                case GeneralTextLocalizationType.SharedLocalization:
                    DB.SharedLocalizations.Update(item.ToObject<SharedLocalization>());
                    break;
            }
            return SaveAndRedirectToStartPage();
        }


        [Route("Interface/OtherPagesPOST"), HttpPost]
        public async Task<IActionResult> OtherPagesPOST(OtherPagesLocalizationType type)
        {
            JToken item = (JToken)GenerateObjectFromForm();

            switch (type)
            {
                case OtherPagesLocalizationType.NewsPageLocalization:
                    DB.NewsPageLocalizations.Update(item.ToObject<NewsPageLocalization>());
                    break;
                case OtherPagesLocalizationType.PortfolioPageLocalization:
                    DB.PortfolioPageLocalizations.Update(item.ToObject<PortfolioPageLocalization>());
                    break;
                case OtherPagesLocalizationType.PrivacyPageLocalization:
                    DB.PrivacyPageLocalizations.Update(item.ToObject<PrivacyPageLocalization>());
                    break;
                case OtherPagesLocalizationType.ServicesPageLocalization:
                    DB.ServicesPageLocalizations.Update(item.ToObject<ServicesPageLocalization>());
                    break;
            }
            return SaveAndRedirectToStartPage();
        }


        [Route("Interface/PopupsPOST"), HttpPost]
        public async Task<IActionResult> PopupsPOST(PopupsLocalizationType type)
        {
            JToken item = (JToken)GenerateObjectFromForm();

            switch (type)
            {
                case PopupsLocalizationType.AcceptOrderPopupLocalization:
                    DB.AcceptOrderPopupLocalizations.Update(item.ToObject<AcceptOrderPopupLocalization>());
                    break;
                case PopupsLocalizationType.CallPopupLocalization:
                    DB.CallPopupLocalizations.Update(item.ToObject<CallPopupLocalization>());
                    break;
                case PopupsLocalizationType.ContactsPopupLocalization:
                    DB.ContactsPopupLocalizations.Update(item.ToObject<ContactsPopupLocalization>());
                    break;
                case PopupsLocalizationType.PortfolioPopupLocalization:
                    DB.PortfolioPopupLocalizations.Update(item.ToObject<PortfolioPopupLocalization>());
                    break;
            }
            return SaveAndRedirectToStartPage();
        }





        private object GenerateObjectFromForm()
        {
            ExpandoObject jsonExpando = new ExpandoObject();
          
            foreach (var key in Request.Form.Keys)
            {
                jsonExpando.TryAdd(key, Request.Form[key].ToString());
            }

            JObject jObj = JObject.FromObject(jsonExpando);
            return JsonConvert.DeserializeObject(jObj.ToString());
        }
        private IActionResult SaveAndRedirectToStartPage()
        {
            DB.SaveChanges();

            if (Request.Form.Keys.Contains("LanguageId"))
            {
                var langFromForm = Request.Form["LanguageId"].ToString();
                if (!string.IsNullOrEmpty(langFromForm))
                {
                    return RedirectToAction("AllPages", "AllPagesInterface");
                }
            }  
            return RedirectToAction("AllPagesByLang", "AllPagesInterface");
        }


    }
}
