using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Events;
using Alfateam.CRM2_0.Models.EditModels.Content.Events;

namespace Alfateam.CRM2_0.Models.CreateModels.Content.Events
{
    public class EventCategoryCreateModel : CreateModel<EventCategory>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
