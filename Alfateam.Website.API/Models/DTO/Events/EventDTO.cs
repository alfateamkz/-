using Alfateam.Core.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Attributes.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam2._0.Models.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alfateam.Website.API.Models.DTO.Events
{
    public class EventDTO : AvailabilityDTOModel<Event>
    {
    
        public string Title { get; set; }
        public string Description { get; set; }
        [ForClientOnly]
        public string ImgPath { get; set; }


        public string? EventOrganizer { get; set; }
        public string? EventMembers { get; set; }



        [ForClientOnly]
        public string Slug => SlugHelper.GetLatynSlug(Title);


        [ForClientOnly]
        public EventCategoryDTO Category { get; set; }
        [ForClientOnly]
        public EventFormatDTO Format { get; set; }
        [ForClientOnly]
        public TimezoneDTO Timezone { get; set; }




        [HiddenFromClient]
        public int TimeZoneId { get; set; }



        [HiddenFromClient]
        public int CategoryId { get; set; }
        [HiddenFromClient]
        public int FormatId { get; set; }



    }
}
