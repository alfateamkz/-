using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Events;

namespace Alfateam.CRM2_0.Models.EditModels.Content.Events
{
    public class EventFormatEditModel : EditModel<EventFormat>
    {
        public string Title { get; set; }
    }
}
