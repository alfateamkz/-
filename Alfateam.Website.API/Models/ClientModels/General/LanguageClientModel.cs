using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.Posts;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.ClientModels.General
{
    public class LanguageClientModel : ClientModel
    {
        public string Title { get; set; }
        public string Code { get; set; }


        public static LanguageClientModel Create(Language item, int? langId)
        {

            var model = new LanguageClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.Code = item.Code;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            return model;
        }
        public static List<LanguageClientModel> CreateItems(IEnumerable<Language> items, int? langId)
        {
            var models = new List<LanguageClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
