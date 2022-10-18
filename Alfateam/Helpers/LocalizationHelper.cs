using Alfateam.Database.Models;

namespace Alfateam.Helpers
{
    public class LocalizationHelper
    {
        public static HttpContext Context { get; set; }
        public static string GetLocalizedString(List<TranslationItem> translations,string langCode) 
        {
            var found = translations.FirstOrDefault(o => o.Language.Code == langCode);

            if (found == null)
                found = translations.FirstOrDefault(o => o.Language.Code == "RU");
            return found?.Text;
        }
    }
}
