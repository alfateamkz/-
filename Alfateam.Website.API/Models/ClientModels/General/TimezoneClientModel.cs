using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.General;

namespace Alfateam.Website.API.Models.ClientModels.General
{
    public class TimezoneClientModel : ClientModel
    {
        public string Title { get; set; }
        public TimeSpan Offset { get; set; }



        public static TimezoneClientModel Create(Alfateam2._0.Models.General.TimeZone item, int? langId)
        {
            var model = new TimezoneClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.Offset = item.Offset;

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
        public static List<TimezoneClientModel> CreateItems(IEnumerable<Alfateam2._0.Models.General.TimeZone> items, int? langId)
        {
            var models = new List<TimezoneClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
