using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Events;

namespace Alfateam.CRM2_0.Models.EditModels.Content.Events
{
    public class EventCategoryEditModel : EditModel<EventCategory>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
