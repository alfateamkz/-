using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Outstaff;

namespace Alfateam.Website.API.Models.ClientModels.Outstaff
{
    public class OutstaffItemGradeClientModel : ClientModel
    {
        public string Title { get; set; }
        public List<OutstaffItemGradeColumnClientModel> Prices { get; set; } = new List<OutstaffItemGradeColumnClientModel>();

        public static OutstaffItemGradeClientModel Create(OutstaffItemGrade item, int? langId, int? countryId)
        {

            var model = new OutstaffItemGradeClientModel();

            model.Id = item.Id;
            model.Title = item.Title;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                }
            }

            model.Prices = OutstaffItemGradeColumnClientModel.CreateItems(item.Prices, langId, countryId);

            return model;
        }
        public static List<OutstaffItemGradeClientModel> CreateItems(List<OutstaffItemGrade> items, int? langId, int? countryId)
        {
            var models = new List<OutstaffItemGradeClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId, countryId));
            }
            return models;
        }
    }
}
