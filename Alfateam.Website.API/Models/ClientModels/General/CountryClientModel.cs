using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.ClientModels.General
{
    public class CountryClientModel : ClientModel
    {
        public string Title { get; set; }
        public string Code { get; set; }


        public static CountryClientModel Create(Country item, int? langId)
        {

            var model = new CountryClientModel();

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
        public static List<CountryClientModel> CreateItems(IEnumerable<Country> items, int? langId)
        {
            var models = new List<CountryClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
