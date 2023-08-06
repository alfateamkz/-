using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.ClientModels.Outstaff
{

    /// <summary>
    /// Сущность колонки периода времени в аутстафф таблице
    /// У нас на сайте их три(до 3 месяцев, до 6 месяцев, от 6 месяцев)
    /// </summary>
    public class OutstaffColumnClientModel : ClientModel
    {
        public string Title { get; set; }
        public double Discount { get; set; }

        public static OutstaffColumnClientModel Create(OutstaffColumn item, int? langId)
        {

            var model = new OutstaffColumnClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.Discount = item.Discount;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            return model;
        }
        public static List<OutstaffColumnClientModel> CreateItems(List<OutstaffColumn> items, int? langId)
        {
            var models = new List<OutstaffColumnClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
