using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Models.CreateModels.Events
{
    public class EventCreateModel : CreateModel<Event>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }


        public string? EventOrganizer { get; set; }
        public string? EventMembers { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeZoneId { get; set; }




        public int CategoryId { get; set; }
        public int FormatId { get; set; }


        public int MainLanguageId { get; set; }
    }
}
