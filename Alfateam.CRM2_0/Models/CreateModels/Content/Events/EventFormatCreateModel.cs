using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Events;

namespace Alfateam.CRM2_0.Models.CreateModels.Content.Events
{
    public class EventFormatCreateModel : CreateModel<EventFormat>
    {
        public string Title { get; set; }
    }
}
