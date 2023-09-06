using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Content.Events;

namespace Alfateam.CRM2_0.Models.CreateModels.Content.Events
{
    public class EventCreateModel : CreateModel<Event>
    {
        public string Title { get; set; }
        public string Description { get; set; }


        public string? EventOrganizer { get; set; }
        public string? EventMembers { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int TimeZoneId { get; set; }




        public int CategoryId { get; set; }
        public int FormatId { get; set; }
    }
}
