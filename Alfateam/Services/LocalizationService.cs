using Alfateam.Database;
using Alfateam.Database.Models;
using Alfateam.Database.Models.Abstractions;
using Alfateam.Database.Models.Localizations.Texts;
using Alfateam.Database.Models.Localizations.Texts.OtherPages;
using Alfateam.Database.Models.Localizations.Texts.Popups;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Alfateam.Services
{
    public class LocalizationService
    {
        private readonly DatabaseContext db;
        private readonly IHttpContextAccessor httpContextAccessor;
        public LocalizationService(DatabaseContext db, IHttpContextAccessor accessor)
        {
            this.db = db;
            this.httpContextAccessor = accessor;
        }

        public List<Language> GetLanguages()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                return db.Languages.Where(o => o.IsShown).ToList();
            }
        }
        public Language GetCurrentLanguage()
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                Language lang = null;
                try
                {
                    if (httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("Language"))
                    {
                        int id = Convert.ToInt32(httpContextAccessor.HttpContext.Request.Cookies["Language"]);
                        lang = db.Languages.FirstOrDefault(o => o.Id == id);
                    }
                    else
                    {
                        lang = db.Languages.FirstOrDefault(o => o.Code == "RU");
                    }
                }
                catch { }

                return lang;
            }
        }



        #region Get localization texts methods

        #region Other pages
        public NewsPageLocalization GetNewsPageLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.NewsPageLocalizations, lang.Id);
        }
        public PortfolioPageLocalization GetPortfolioPageLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.PortfolioPageLocalizations, lang.Id);
        }
        public PrivacyPageLocalization GetPrivacyPageLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.PrivacyPageLocalizations, lang.Id);
        }
        public ServicesPageLocalization GetServicesPageLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.ServicesPageLocalizations, lang.Id);
        }

        #endregion

        #region Popups
        public AcceptOrderPopupLocalization GetAcceptOrderPopupLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.AcceptOrderPopupLocalizations, lang.Id);
        }
        public CallPopupLocalization GetCallPopupLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.CallPopupLocalizations, lang.Id);
        }
        public ContactsPopupLocalization GetContactsPopupLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.ContactsPopupLocalizations, lang.Id);
        }
        public PortfolioPopupLocalization GetPortfolioPopupLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.PortfolioPopupLocalizations, lang.Id);
        }
        #endregion

        public CalculatorLocalization GetCalculatorLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.CalculatorLocalizations, lang.Id);
        }
        public ErrorPagesLocalization GetErrorPagesLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.ErrorPagesLocalizations, lang.Id);
        }
        public MainPageLocalization GetMainPageLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.MainPageLocalizations, lang.Id);
        }
        public MapBlockLocalization GetMapBlockLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.MapBlockLocalizations, lang.Id);
        }
        public SharedLocalization GetSharedLocalization()
        {
            var lang = GetCurrentLanguage();
            return GetLocalization(db.SharedLocalizations, lang.Id);
        }
        #endregion


        private T GetLocalization<T>(DbSet<T> dbset,int langId) where T: LocalizationModel
        {
            T found = dbset.FirstOrDefault(o => o.LanguageId == langId);
            if(found == null)
            {
                found = dbset.FirstOrDefault(o => o.LanguageId == 1); // русский язык
            }
            return found;
        }
    }
}
