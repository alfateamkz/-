using Alfateam.Administration.Models.StaticTextsConstructor;
using Alfateam.DB;
using Alfateam2._0.Models.Localization.Texts.Grouping;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Alfateam.ForPubilcWebsites.API.Jobs
{
    public static class StaticLocalizationFileGenerationJob
    {
        private static string StaticTextsFolder = "uploads/wwwroot/static_texts";
        public static void Start()
        {
            Task.Run(async() =>
            {
                while(true)
                {
                    using (AdmininstrationDbContext db = new AdmininstrationDbContext())
                    {
                        var sets = db.TextsSets.Include(o => o.TextsSetLanguageZones).ThenInclude(o => o.Language)
                                               .Include(o => o.TextsSetLanguageZones).ThenInclude(o => o.Texts).ThenInclude(o => o.Fields)
                                               .Include(o => o.TextsSetLanguageZones).ThenInclude(o => o.Texts).ThenInclude(o => o.SubTexts)
                                               .Include(o => o.Product)
                                               .Where(o => !o.Product.IsDeleted);

                        foreach (var set in sets)
                        {
                            foreach(var languageZone in set.TextsSetLanguageZones.Where(o => !o.IsDeleted))
                            {
                                var rootTexts = new Dictionary<string, object>();
                                foreach (var text in languageZone.Texts)
                                {
                                    rootTexts.Add(text.ClassName, GetTextsDictionary(text));
                                }
                                SaveFile(rootTexts, $"{set.UniqueIdentifier}/{languageZone.Language.Code}/texts.json");
                            }
                        }
                    }

                    await Task.Delay(TimeSpan.FromHours(1));
                }
            });
        }  

        private static void SaveFile(Dictionary<string, object> structure, string path)
        {
            if (!Directory.Exists(StaticTextsFolder))
            {
                Directory.CreateDirectory(StaticTextsFolder);
            }

            var filepath = Path.Combine(StaticTextsFolder, path);

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }

            var jsonStr = JsonConvert.SerializeObject(structure);
            File.WriteAllText(filepath, jsonStr);
        }


        private static Dictionary<string, object> GetTextsDictionary(StaticTextsModel texts)
        {
            var dictionary = new Dictionary<string,object>();

            foreach(var field in texts.Fields)
            {
                if (field is HTMLTextField htmlField)
                {
                    dictionary.Add(field.FieldName, htmlField.HTML);
                }
                else if (field is ImageField imageField)
                {
                    dictionary.Add(field.FieldName, imageField.Base64);
                }
                else if (field is VideoField videoField)
                {
                    dictionary.Add(field.FieldName, videoField.URL);
                }
                else if (field is SimpleTextField simpleTextField)
                {
                    dictionary.Add(field.FieldName, simpleTextField.Text);
                }
                else throw new NotImplementedException();
            }

            foreach(var subtext in texts.SubTexts)
            {
                dictionary.Add(subtext.ClassName, GetTextsDictionary(subtext));
            }

            return dictionary;
        }
    }
}
