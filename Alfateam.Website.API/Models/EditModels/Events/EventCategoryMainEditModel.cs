using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Models.EditModels.Events
{
    public class EventCategoryMainEditModel : EditModel<EventCategory>
    {
        public string Title { get; set; }
        public string? Description { get; set; }



        public int MainLanguageId { get; set; }
    }
}
