using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.ClientModels.General
{
    public class CurrencyClientModel : ClientModel
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }


        public static CurrencyClientModel Create(Currency item, int? langId)
        {

            var model = new CurrencyClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.Code = item.Code;
            model.Symbol = item.Symbol;

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
        public static List<CurrencyClientModel> CreateItems(IEnumerable<Currency> items, int? langId)
        {
            var models = new List<CurrencyClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
