using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Events;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Alfateam.Website.API.Models.ClientModels.Events
{
    public class EventCategoryClientModel : ClientModel
    {
        protected EventCategoryClientModel() { }

        public string Title { get; set; }
        public string? Description { get; set; }

        
        public string Slug => SlugHelper.GetLatynSlug(Title);

        public static EventCategoryClientModel Create(EventCategory item, int? langId)
        {

            var model = new EventCategoryClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.Description = item.Description;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                    model.Description = GetActualValue(model.Description, localization.Description);
                }
            }

            return model;
        }
        public static List<EventCategoryClientModel> CreateItems(IEnumerable<EventCategory> items, int? langId)
        {
            var models = new List<EventCategoryClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
