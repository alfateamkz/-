using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Events;

namespace Alfateam.CRM2_0.Models.ClientModels.Content.Events
{
    public class EventFormatClientModel : ClientModel<EventFormat>
    {
        public string Title { get; set; }
    }
}
