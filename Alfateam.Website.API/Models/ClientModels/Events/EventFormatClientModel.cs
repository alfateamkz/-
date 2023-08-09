using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.Events
{
    public class EventFormatClientModel : ClientModel
    {
        protected EventFormatClientModel() { }

        public string Title { get; set; }
        public string? Description { get; set; }



        public string Slug => SlugHelper.GetLatynSlug(Title);

        public static EventFormatClientModel Create(EventFormat item, int? langId)
        {

            var model = new EventFormatClientModel();

            model.Id = item.Id;
            model.Title = item.Title;

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
        public static List<EventFormatClientModel> CreateItems(List<EventFormat> items, int? langId)
        {
            var models = new List<EventFormatClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
