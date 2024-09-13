using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models.ClientModels.General;
using Alfateam2._0.Models.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.ClientModels.Events
{
    public class EventClientModel : ClientModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }


        public string? EventOrganizer { get; set; }
        public string? EventMembers { get; set; }




        public string Slug => SlugHelper.GetLatynSlug(Title);


        public EventCategoryClientModel Category { get; set; }
        public EventFormatClientModel Format { get; set; }
        public TimezoneClientModel Timezone { get; set; }


        public static EventClientModel Create(Event item, int? langId)
        {

            var model = new EventClientModel();

            model.Id = item.Id;
            model.Title = item.Title;
            model.Description = item.Description;
            model.ImgPath = item.ImgPath;
            model.EventOrganizer = item.EventOrganizer;
            model.EventMembers = item.EventMembers;

            if (item.MainLanguageId != langId)
            {
                var localization = item.Localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
                if (localization != null)
                {
                    model.Title = GetActualValue(model.Title, localization.Title);
                    model.Description = GetActualValue(model.Description, localization.Description);
                    model.ImgPath = GetActualValue(model.ImgPath, localization.ImgPath);
                    model.EventOrganizer = GetActualValue(model.EventOrganizer, localization.EventOrganizer);
                    model.EventMembers = GetActualValue(model.EventMembers, localization.EventMembers);
                }
            }

            model.Category = EventCategoryClientModel.Create(item.Category, langId);
            model.Format = EventFormatClientModel.Create(item.Format, langId);
            model.Timezone = TimezoneClientModel.Create(item.TimeZone, langId);

            return model;
        }
        public static List<EventClientModel> CreateItems(IEnumerable<Event> items, int? langId)
        {
            var models = new List<EventClientModel>();
            foreach (var item in items)
            {
                models.Add(Create(item, langId));
            }
            return models;
        }
    }
}
