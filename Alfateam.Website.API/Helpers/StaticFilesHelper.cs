using Alfateam.Models;
using Alfateam2._0.Models.Localization.Texts.Grouping;
using Newtonsoft.Json;
using System.IO;

namespace Alfateam.Website.API.Helpers
{
    public static class StaticFilesHelper
    {
        private static string LocalizationsFolderPath = "localizations";

        public static void CreateStaticLocalizationsFile(WebsiteLocalizationTexts websiteTexts)
        {
            var filepath = Path.Combine(LocalizationsFolderPath, $"localization_{websiteTexts.LanguageEntity.Code}.json");

            if (File.Exists(filepath))
            {
                File.Delete(filepath);           
            }

            var staticFileModel = new StaticFileModel<WebsiteLocalizationTexts>()
            {
                Value = websiteTexts,
            };
            var jsonStr = JsonConvert.SerializeObject(staticFileModel);
            File.WriteAllText(filepath, jsonStr);
        }
    }
}
