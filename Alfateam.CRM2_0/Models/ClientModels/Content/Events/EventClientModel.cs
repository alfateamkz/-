using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.ClientModels.General;
using Alfateam.CRM2_0.Models.Content.Events;

namespace Alfateam.CRM2_0.Models.ClientModels.Content.Events
{
    public class EventClientModel : ClientModel<Event>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }


        public string? EventOrganizer { get; set; }
        public string? EventMembers { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeZoneClientModel TimeZone { get; set; }





        public EventCategoryClientModel Category { get; set; }
        public EventFormatClientModel Format { get; set; }
    }
}
