using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Models.CreateModels.Events
{
    public class EventCategoryCreateModel : CreateModel<EventCategory>
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        public int MainLanguageId { get; set; }
    }
}
